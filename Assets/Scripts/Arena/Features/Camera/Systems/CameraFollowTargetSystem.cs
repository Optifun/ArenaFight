using Arena.Camera.Components;
using Arena.Physics.Components;
using ME.ECS;
using UnityEngine;

namespace Arena.Camera.Systems
{
#if ECS_COMPILE_IL2CPP_OPTIONS
    [Unity.IL2CPP.CompilerServices.Il2CppSetOptionAttribute(Unity.IL2CPP.CompilerServices.Option.NullChecks, false),
     Unity.IL2CPP.CompilerServices.Il2CppSetOptionAttribute(Unity.IL2CPP.CompilerServices.Option.ArrayBoundsChecks, false),
     Unity.IL2CPP.CompilerServices.Il2CppSetOptionAttribute(Unity.IL2CPP.CompilerServices.Option.DivideByZeroChecks, false)]
#endif
    public sealed class CameraFollowTargetSystem : ISystemFilter
    {
        private CameraFeature feature;

        public World world { get; set; }

        void ISystemBase.OnConstruct()
        {
            this.GetFeature(out this.feature);
        }

        void ISystemBase.OnDeconstruct()
        {
        }

#if !CSHARP_8_OR_NEWER
        bool ISystemFilter.jobs => false;
        int ISystemFilter.jobsBatchCount => 64;
#endif
        Filter ISystemFilter.filter { get; set; }

        private Filter _targetFilter;

        Filter ISystemFilter.CreateFilter()
        {
            Filter.Create("Filter-CameraTarget")
               .With<CameraTargetTag>()
               .With<PositionComponent>()
               .Push(ref _targetFilter);

            return Filter.Create("Filter-CameraFollowTargetSystem")
                      .With<CameraTag>()
                      .Push();
        }

        private static readonly float InterpStep = RevSquare(0.2f);

        private static float RevSquare(float t) => 1 - (1 - t) * (1 - t);

        void ISystemFilter.AdvanceTick(in Entity entity, in float deltaTime)
        {
            ref readonly var camera = ref entity.Read<CameraConfigComponent>();
            ref readonly var position = ref entity.Read<PositionComponent>();
            ref var speed = ref entity.Get<SpeedComponent>();

            foreach (Entity targetEntity in _targetFilter)
            {
                ref readonly PositionComponent targetPosition = ref targetEntity.Read<PositionComponent>();
                var movementDirection = targetPosition.Value - position.Value;
                if (movementDirection.sqrMagnitude < camera.Value.PositionThreshold)
                {
                    speed.Speed = Vector3.zero;
                }
                var newSpeed = new Vector3(movementDirection.x, 0, movementDirection.z);
                speed.Speed = Vector3.Lerp(speed.Speed, newSpeed * newSpeed.sqrMagnitude, deltaTime * InterpStep);
            }
        }
    }
}