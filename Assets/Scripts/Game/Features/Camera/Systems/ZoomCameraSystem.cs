using Game.Features.Camera.Components;
using Game.Features.Movement;
using Leopotam.Ecs;
using UnityEngine;

namespace Game.Features.Camera.Systems
{
    public class ZoomCameraSystem : IEcsRunSystem
    {
        private EcsFilter<CameraComponent, PositionComponent> _cameraFilter;

        public void Run()
        {
            foreach (var i in _cameraFilter)
            {
                ref var camera = ref _cameraFilter.Get1(i);
                ref var position = ref _cameraFilter.Get2(i);
                position.Position = CorrectPosition(camera, position.Position);
            }
        }

        private static Vector3 CorrectPosition(CameraComponent camera, Vector3 vector3) =>
            new Vector3(vector3.x, camera.YOffset, vector3.z);
    }
}