using Game.Features.Camera.Components;
using Game.Features.Movement;
using Game.Shared.Components;
using Leopotam.Ecs;
using UnityEngine;

namespace Game.Features.Camera.Systems
{
    public class ZoomCameraSystem : IEcsRunSystem
    {
        private EcsFilter<CameraComponent, PositionComponent, UnityObject<UnityEngine.Camera>> _cameraFilter;

        public void Run()
        {
            foreach (var i in _cameraFilter)
            {
                ref var cameraConfig = ref _cameraFilter.Get1(i);
                ref var camera = ref _cameraFilter.Get3(i);
                CorrectPosition(cameraConfig, camera.Value.transform);
            }
        }

        private static void CorrectPosition(CameraComponent camera, Transform cameraTransform)
        {
            var angle = 90 - camera.Config.CameraAngle;
            var verticalOffset = Mathf.Pow(2, camera.Config.Zoom);
            var horizontalOffset = verticalOffset * Mathf.Sin(Mathf.Deg2Rad * angle);

            cameraTransform.localPosition = new Vector3(0, verticalOffset, -horizontalOffset);
            cameraTransform.rotation = Quaternion.Euler(90 - angle, 0, 0);
        }
    }
}