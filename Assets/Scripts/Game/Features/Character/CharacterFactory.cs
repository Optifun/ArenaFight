using Game.Features.Character.Behaviours;
using Game.Features.Health;
using Game.Features.Movement;
using Game.Features.Tags;
using Game.Services;
using Game.Shared.Components;
using Leopotam.Ecs;
using UnityEngine;
using CharacterInfo = StaticData.CharacterInfo;

namespace Game.Features.Character
{
    public class CharacterFactory
    {
        private readonly EcsWorld _world;
        private readonly CharacterInfo _characterInfo;

        public CharacterFactory(EcsWorld world, CharacterInfo characterInfo)
        {
            _characterInfo = characterInfo;
            _world = world;
        }

        public EcsEntity CreatePlayerEntity(Vector3 position)
        {
            var maxHealth = _characterInfo.BaseStats.MaxHealth;

            EcsEntity entity = _world.NewEntity();

            entity
                .Replace(new CharacterTag())
                .Replace(new PositionComponent {Position = position})
                .Replace(new SpeedComponent() {MaximumSpeed = _characterInfo.BaseStats.Speed})
                .Replace(new HealthComponent {MaxHealth = maxHealth, Health = maxHealth})
                .Replace(new ExperienceComponent {Level = 1, CurrentXP = 0, ExperienceCapacity = 1000});

            SpawnCharacter(position, entity);

            return entity;
        }

        private CharacterView SpawnCharacter(Vector3 position, EcsEntity playerEntity)
        {
            var go = Object.Instantiate(_characterInfo.CharacterPrefab, position, Quaternion.identity);
            var entityReference = go.GetComponent<EntityReference>();
            var view = go.GetComponent<CharacterView>();

            entityReference.Entity = playerEntity;

            playerEntity
                .Replace(new UnityObject<Transform>(go.transform))
                .Replace(new UnityObject<EntityReference>(entityReference))
                .Replace(new UnityObject<CharacterView>(view));

            return view;
        }
    }
}