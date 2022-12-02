using System;
using Leopotam.Ecs;
using UnityEngine;
using Zenject;

namespace Infrastructure.Installers
{
    public class ArenaInstaller : MonoInstaller, IInitializable
    {
        private EcsWorld _world;
        private EcsSystems _systems;

        private bool _initializationCompleted = false;
        private EcsSystems _simulationSystems;

        public override void InstallBindings()
        {
            Container.Bind<IInitializable>().To<ArenaInstaller>().FromInstance(this);
        }

        public void Initialize()
        {
            _world = new EcsWorld();
            _systems = new EcsSystems(_world);
            _simulationSystems = new EcsSystems(_world);

            _systems.Add(new TestSystem());

            _systems.Init();
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