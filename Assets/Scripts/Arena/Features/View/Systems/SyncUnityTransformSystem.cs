using Arena.Components;
using Arena.Physics.Components;
using ME.ECS;

namespace Arena.View.Systems
{
#if ECS_COMPILE_IL2CPP_OPTIONS
    [Unity.IL2CPP.CompilerServices.Il2CppSetOptionAttribute(Unity.IL2CPP.CompilerServices.Option.NullChecks, false),
     Unity.IL2CPP.CompilerServices.Il2CppSetOptionAttribute(Unity.IL2CPP.CompilerServices.Option.ArrayBoundsChecks, false),
     Unity.IL2CPP.CompilerServices.Il2CppSetOptionAttribute(Unity.IL2CPP.CompilerServices.Option.DivideByZeroChecks, false)]
#endif
    public sealed class SyncUnityTransformSystem : ISystemFilter
    {
        public World world { get; set; }

        void ISystemBase.OnConstruct()
        {
        }

        void ISystemBase.OnDeconstruct()
        {
        }

#if !CSHARP_8_OR_NEWER
        bool ISystemFilter.jobs => false;
        int ISystemFilter.jobsBatchCount => 64;
#endif
        Filter ISystemFilter.filter { get; set; }

        Filter ISystemFilter.CreateFilter()
        {
            return Filter.Create("Filter-SyncUnityTransformSystem").With<UnityTransform>().Push();
        }

        void ISystemFilter.AdvanceTick(in Entity entity, in float deltaTime)
        {
            ref var transform = ref entity.Get<UnityTransform>();
            var position = transform.Value.position;
            var rotation = transform.Value.rotation;

            if (entity.TryRead(out PositionComponent positionComponent))
            {
                position = positionComponent.Value;
            }
            if (entity.TryRead(out RotationComponent rotationComponent))
            {
                rotation = rotationComponent.Value;
            }
            transform.Value.SetPositionAndRotation(position, rotation);
        }
    }
}