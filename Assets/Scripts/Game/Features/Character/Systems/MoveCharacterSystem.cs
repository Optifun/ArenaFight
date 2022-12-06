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

        public void Run()
        {
            foreach (var i in _character)
            {
                ref var playerSpeed = ref _character.Get2(i);

                if (_input.TryGet1(out var input) && !input.IsNull())
                {
                    ref var inputComponent = ref input.Unref();
                    Vector3.LerpUnclamped(playerSpeed.Speed, inputComponent.Direction * playerSpeed.MaximumSpeed,
                        SmoothStep(Time.fixedTime));
                }
            }
        }

        private float SmoothStep(float t)
        {
            float v1 = t * t;
            float v2 = 1 - (1 - t) * (1 - t);
            return Mathf.Lerp(v1, v2, t);
        }
    }
}