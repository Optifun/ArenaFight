using Game.Features.Camera.Components;
using Game.Features.Movement;
using Game.Features.Tags;
using Game.Shared.Components;
using Leopotam.Ecs;
using StaticData;
using UnityEngine;

namespace Game.Features.Camera
{
    public class CameraFactory
    {
        private readonly CameraConfig _config;
        private readonly EcsWorld _world;

        public CameraFactory(CameraConfig config, EcsWorld world)
        {
            _config = config;
            _world = world;
        }

        public EcsEntity CreateCameraEntity(Vector3 position)
        {
            var go = Object.Instantiate(_config.Prefab, position, Quaternion.identity);
            var camera = go.GetComponentInChildren<UnityEngine.Camera>();
            var entity = _world.NewEntity();
            
            entity.Replace(new CameraTag())
                .Replace(new CameraComponent {Config = _config, YOffset = 10})
                .Replace(new PositionComponent())
                .Replace(new SpeedComponent {MaximumSpeed = _config.MaximumSpeed})
                .Replace(new UnityObject<UnityEngine.Camera>(camera))
                .Replace(new UnityObject<Transform>(go.transform));

            return entity;
        }
    }
}