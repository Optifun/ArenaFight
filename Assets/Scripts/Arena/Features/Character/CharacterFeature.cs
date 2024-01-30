using Arena.Camera.Components;
using Arena.Character.Components;
using Arena.Character.Views;
using Arena.Components;
using Arena.Movement.Systems;
using Arena.Physics.Components;
using ME.ECS;
using UnityEngine;
using CharacterInfo = Arena.StaticData.CharacterInfo;

namespace Arena.Character
{
#if ECS_COMPILE_IL2CPP_OPTIONS
    [Unity.IL2CPP.CompilerServices.Il2CppSetOptionAttribute(Unity.IL2CPP.CompilerServices.Option.NullChecks, false),
     Unity.IL2CPP.CompilerServices.Il2CppSetOptionAttribute(Unity.IL2CPP.CompilerServices.Option.ArrayBoundsChecks, false),
     Unity.IL2CPP.CompilerServices.Il2CppSetOptionAttribute(Unity.IL2CPP.CompilerServices.Option.DivideByZeroChecks, false)]
#endif
    public sealed class CharacterFeature : Feature
    {
        [SerializeField] private CharacterInfo _characterInfo;
        [SerializeField] private CharacterView _characterViewSource;

        private Filter _playerFilter;
        private ViewId _characterViewId;

        protected override void OnConstruct()
        {
            Filter.Create("Filter-Player").With<PlayerId>().With<CharacterTag>().Push(ref _playerFilter);
            _characterViewId = Worlds.currentWorld.RegisterViewSource(_characterViewSource);
            AddSystem<MoveCharacterSystem>();
        }

        protected override void OnConstructLate()
        {
            CreatePlayerEntity(0, Vector3.zero);
        }

        protected override void OnDeconstruct()
        {
        }

        public Entity GetCharacter(int playerId)
        {
            foreach (Entity entity in _playerFilter)
            {
                if (entity.Read<PlayerId>().Id == playerId)
                {
                    return entity;
                }
            }
            Debug.LogWarning("you are trying to find entity that does not exist");
            return Entity.Empty;
        }

        public Entity CreatePlayerEntity(int playerId, Vector3 position)
        {
            var maxHealth = _characterInfo.BaseStats.MaxHealth;

            ref var entity = ref world.AddEntity();

            entity
                .Set(new PlayerId() {Id = playerId})
                .Set(new CharacterTag())
                .Set(new CameraTargetTag())
                .Set(new PositionComponent {Value = position})
                .Set(new SpeedComponent() {MaximumSpeed = _characterInfo.BaseStats.Speed})
                .Set(new HealthComponent {MaxHealth = maxHealth, Health = maxHealth})
                .Set(new ExperienceComponent {Level = 1, CurrentXP = 0, ExperienceCapacity = 1000});

            SpawnCharacter(position, entity);

            return entity;
        }

        private void SpawnCharacter(Vector3 position, Entity playerEntity)
        {
            playerEntity.InstantiateView(_characterViewId);
        }
    }
}