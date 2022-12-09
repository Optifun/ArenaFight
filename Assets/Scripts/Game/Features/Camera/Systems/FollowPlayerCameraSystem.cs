using Extensions;
using Game.Features.Camera.Components;
using Game.Features.Movement;
using Game.Features.Tags;
using Leopotam.Ecs;
using UnityEngine;

namespace Game.Features.Camera.Systems
{
    public class FollowPlayerCameraSystem : IEcsRunSystem
    {
        private EcsFilter<CharacterTag, PositionComponent> _characterFilter;
        private EcsFilter<CameraComponent, PositionComponent, SpeedComponent> _cameraFilter;
        private static readonly float InterpStep = RevSquare(0.2f);

        public void Run()
        {
            if (!_characterFilter.TryGet2(out EcsComponentRef<PositionComponent> positionRef))
                return;

            ref var characterPosition = ref positionRef.Unref();

            foreach (var i in _cameraFilter)
            {
                ref CameraComponent camera = ref _cameraFilter.Get1(i);
                ref PositionComponent position = ref _cameraFilter.Get2(i);
                ref SpeedComponent speed = ref _cameraFilter.Get3(i);

                var movementDirection = characterPosition.Position - position.Position;
                if (movementDirection.sqrMagnitude < camera.PositionThreshold) speed.Speed = Vector3.zero;
                var newSpeed = new Vector3(movementDirection.x, 0, movementDirection.z);
                speed.Speed = Vector3.Lerp(speed.Speed, newSpeed * newSpeed.sqrMagnitude, InterpStep);
            }
        }

        private static float RevSquare(float t) => 1 - (1 - t) * (1 - t);
    }
}