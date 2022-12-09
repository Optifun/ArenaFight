using System;
using Extensions;
using Game.Features.Character;
using Game.Features.Character.Systems;
using Game.Features.Events;
using Game.Features.Movement;
using Game.Shared.Services;
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
            Container.Bind<EcsWorld>().ToSelf().AsSingle();
            Container.Bind<CharacterInfo>().FromInstance(CharacterData).AsCached();
            Container.Bind<IInitializable>().To<ArenaInstaller>().FromInstance(this);
            Container.Bind<CharacterFactory>().ToSelf().AsSingle();
            Container.Bind<IInputService>().FromInstance(NewInputService());

            Container.Bind<InitEventSystem>().ToSelf().AsSingle();
            Container.Bind<InputSystem>().ToSelf().AsSingle();
            Container.Bind<SpawnCharacterSystem>().ToSelf().AsSingle();
            Container.Bind<MoveCharacterSystem>().ToSelf().AsSingle();
            Container.Bind<ApplySpeedSystem>().ToSelf().AsSingle();
            Container.Bind<SyncPositionSystem>().ToSelf().AsSingle();
        }

        public void Initialize()
        {
            _world = Container.Resolve<EcsWorld>();
            _systems = new EcsSystems(_world);
            _simulationSystems = new EcsSystems(_world);

#if UNITY_EDITOR
            Leopotam.Ecs.UnityIntegration.EcsWorldObserver.Create(_world);
            Leopotam.Ecs.UnityIntegration.EcsSystemsObserver.Create(_systems);
            Leopotam.Ecs.UnityIntegration.EcsSystemsObserver.Create(_simulationSystems);
#endif
            _systems
                .AddResolved<InitEventSystem>(Container)
                .AddResolved<SpawnCharacterSystem>(Container);

            _simulationSystems
                .AddResolved<InputSystem>(Container)
                .AddResolved<MoveCharacterSystem>(Container)
                .AddResolved<ApplySpeedSystem>(Container)
                .AddResolved<SyncPositionSystem>(Container);

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

        private IInputService NewInputService()
        {
            var go = new GameObject();
            return go.AddComponent<KeyboardInputService>();
        }
    }

    public struct TestSystem : IEcsInitSystem
    {
        public void Init() =>
            Debug.Log("ECS is working");
    }
}