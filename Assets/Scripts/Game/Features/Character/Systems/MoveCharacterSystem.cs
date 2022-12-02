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
        private EcsFilter<CharacterTag, PositionComponent> _character;

        public void Run()
        {
            foreach (var i in _character)
            {
                ref var playerPosition = ref _character.Get2(i);
                if (_input.TryGet1(out var input) && !input.IsNull())
                {
                    ref var inputComponent = ref input.Unref();
                    playerPosition.Position += inputComponent.Direction * Time.fixedTime;
                }
            }
        }
    }
}