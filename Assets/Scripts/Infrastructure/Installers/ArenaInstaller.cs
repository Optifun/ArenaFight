using System;
using Extensions;
using Game.Features.Character;
using Game.Features.Character.Systems;
using Leopotam.Ecs;
using UnityEngine;
using Zenject;
using CharacterInfo = StaticData.CharacterInfo;

namespace Infrastructure.Installers
{
    public class ArenaInstaller : MonoInstaller, IInitializable
    {
        [SerializeField] private CharacterInfo CharacterData;

        private EcsWorld _world;
        private EcsSystems _systems;
        private EcsSystems _simulationSystems;

        private bool _initializationCompleted = false;

        public override void InstallBindings()
        {
            Container.Bind<CharacterInfo>().FromInstance(CharacterData).AsCached();
            Container.Bind<IInitializable>().To<ArenaInstaller>().FromInstance(this);
            Container.Bind<CharacterFactory>().ToSelf().AsSingle();
            Container.Bind<SpawnCharacterSystem>().ToSelf().AsSingle();
            Container.Bind<MoveCharacterSystem>().ToSelf().AsSingle();
            Container.Bind<EcsWorld>().ToSelf().AsSingle();
        }

        public void Initialize()
        {
            _world = Container.Resolve<EcsWorld>();
            _systems = new EcsSystems(_world);
            _simulationSystems = new EcsSystems(_world);

            _systems
                .AddResolved<SpawnCharacterSystem>(Container);

            _simulationSystems
                .AddResolved<MoveCharacterSystem>(Container);

            _systems.Init();
            _simulationSystems.Init();
            _initializationCompleted = true;
        }

        private void Update()
        {
            if (!_initializationCompleted) return;
            _systems.Run();
        }

        private void FixedUpdate()
        {
            if (!_initializationCompleted) return;
            _simulationSystems.Run();
        }
    }

    public struct TestSystem : IEcsInitSystem
    {
        public void Init() =>
            Debug.Log("ECS is working");
    }
}