using Arena.Utils;
using ME.ECS;
using Scripts.Arena.Components;
using Scripts.Arena.Features.Components;
using UnityEngine;

namespace Scripts.Arena.Features.Movement.Systems
{
#if ECS_COMPILE_IL2CPP_OPTIONS
    [Unity.IL2CPP.CompilerServices.Il2CppSetOptionAttribute(Unity.IL2CPP.CompilerServices.Option.NullChecks, false),
     Unity.IL2CPP.CompilerServices.Il2CppSetOptionAttribute(Unity.IL2CPP.CompilerServices.Option.ArrayBoundsChecks, false),
     Unity.IL2CPP.CompilerServices.Il2CppSetOptionAttribute(Unity.IL2CPP.CompilerServices.Option.DivideByZeroChecks, false)]
#endif
    public sealed class MoveCharacterSystem : ISystemFilter
    {
        private CharacterFeature _characterFeature;

        public World world { get; set; }

        void ISystemBase.OnConstruct()
        {
            this.GetFeature(out _characterFeature);
        }

        void ISystemBase.OnDeconstruct()
        {
        }

#if !CSHARP_8_OR_NEWER
        bool ISystemFilter.jobs => false;
        int ISystemFilter.jobsBatchCount => 64;
#endif
        Filter ISystemFilter.filter { get; set; }
        private readonly float _interpolationStep = SmoothStep(0.3f);

        Filter ISystemFilter.CreateFilter()
        {
            return Filter.Create("Filter-Input").With<InputComponent>().Push();
        }

        void ISystemFilter.AdvanceTick(in Entity inputEntity, in float deltaTime)
        {
            ref readonly var inputComponent = ref inputEntity.Read<InputComponent>();
            ref readonly var playerInput = ref inputEntity.Read<PlayerId>();

            Entity characterEntity = _characterFeature.GetCharacter(playerInput.Id);
            if (characterEntity.IsEmpty())
            {
                return;
            }

            ref var playerSpeed = ref characterEntity.Get<SpeedComponent>();

            if (inputComponent.Value == Vector2.zero && playerSpeed.Speed.sqrMagnitude < 0.001)
            {
                playerSpeed.Speed = Vector3.zero;
            }
            else
            {
                var newSpeed = inputComponent.Value * playerSpeed.MaximumSpeed;
                playerSpeed.Speed = Vector3.LerpUnclamped(playerSpeed.Speed, newSpeed.AsX0Z(), _interpolationStep);
            }
        }

        private static float SmoothStep(float t)
        {
            float v1 = t * t;
            float v2 = 1 - (1 - t) * (1 - t);
            return Mathf.Lerp(v1, v2, t);
        }
    }
}