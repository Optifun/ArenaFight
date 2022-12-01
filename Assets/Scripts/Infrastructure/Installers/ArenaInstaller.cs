using Leopotam.Ecs;
using UnityEngine;
using Zenject;

namespace Infrastructure.Installers
{
    public class ArenaInstaller : MonoInstaller, IInitializable, ITickable
    {
        private EcsWorld _world;
        private EcsSystems _systems;

        public override void InstallBindings()
        {
            Container.Bind<IInitializable>().To<ArenaInstaller>().FromInstance(this);
        }

        public void Initialize()
        {
            _world = new EcsWorld();
            _systems = new EcsSystems(_world);

            _systems.Add(new TestSystem());

            _systems.Init();
        }

        public void Tick() =>
            _systems.Run();
    }

    public struct TestSystem : IEcsInitSystem
    {
        public void Init() =>
            Debug.Log("ECS is working");
    }
}