using Game.Features.Health;
using Game.Features.Movement;
using Game.Features.Tags;
using Leopotam.Ecs;
using UnityEngine;

namespace Game.Features.Character
{
    public class CharacterFactory
    {
        private readonly EcsWorld _world;

        public CharacterFactory(EcsWorld world)
        {
            _world = world;
        }

        public EcsEntity CreatePlayer(Vector3 position)
        {
            EcsEntity entity = _world.NewEntity();
            entity.Get<CharacterTag>();
            entity.Replace(new PositionComponent {Position = position});
            entity.Replace(new HealthComponent {MaxHealth = 100, Health = 100});
            entity.Replace(new ExperienceComponent {Level = 1, CurrentXP = 0, ExperienceCapacity = 1000});
            
            return entity;
        }
    }
}