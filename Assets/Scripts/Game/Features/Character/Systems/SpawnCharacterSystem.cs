using Leopotam.Ecs;
using UnityEngine;

namespace Game.Features.Character.Systems
{
    public class SpawnCharacterSystem : IEcsInitSystem
    {
        private readonly CharacterFactory _factory;

        public SpawnCharacterSystem(CharacterFactory factory)
        {
            _factory = factory;
        }

        public void Init()
        {
            _factory.CreatePlayerEntity(Vector3.zero);
        }
    }
}