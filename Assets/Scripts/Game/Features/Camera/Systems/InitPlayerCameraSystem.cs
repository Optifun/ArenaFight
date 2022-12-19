using Leopotam.Ecs;
using UnityEngine;

namespace Game.Features.Camera.Systems
{
    public class InitPlayerCameraSystem : IEcsInitSystem
    {
        private readonly CameraFactory _factory;

        public InitPlayerCameraSystem(CameraFactory factory) => 
            _factory = factory;

        public void Init() =>
            _factory.CreateCameraEntity(Vector3.zero);
    }
}