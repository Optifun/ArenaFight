using System;
using Extensions;
using Game.Features.Movement;
using Game.Features.Tags;
using Leopotam.Ecs;
using UnityEngine;

namespace Game.Features.Character.Systems
{
    public class MoveCharacterSystem : IEcsRunSystem
    {
        private EcsFilter<InputComponent> _input;
        private EcsFilter<CharacterTag, SpeedComponent> _character;

        private readonly float InterpolationStep = SmoothStep(0.3f);

        public void Run()
        {
            foreach (var i in _character)
            {
                ref var playerSpeed = ref _character.Get2(i);

                if (!_input.TryGet1(out var input) || input.IsNull()) continue;

                ref var inputComponent = ref input.Unref();
                if (inputComponent.Direction == Vector3.zero && playerSpeed.Speed.sqrMagnitude < 0.001)
                {
                    playerSpeed.Speed = Vector3.zero;
                }
                else
                {
                    var newSpeed = inputComponent.Direction * playerSpeed.MaximumSpeed;
                    playerSpeed.Speed = Vector3.LerpUnclamped(playerSpeed.Speed, newSpeed, InterpolationStep);
                }
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