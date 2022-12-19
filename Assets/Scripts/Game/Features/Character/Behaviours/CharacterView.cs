using Game.Features.Movement;
using Game.Shared.Services;
using Leopotam.Ecs;
using UnityEngine;

namespace Game.Features.Character.Behaviours
{
    public class CharacterView : EntityView
    {
        [SerializeField] private Animator _animator;
        [SerializeField] private Transform _model;

        private static readonly int WalkSpeed = Animator.StringToHash("WalkSpeed");


        public override void OnViewStateUpdated()
        {
            var speedComponent = Entity.Get<SpeedComponent>();
            if (speedComponent.Speed != Vector3.zero)
            {
                var nextRotation = Quaternion.LookRotation(speedComponent.Speed);
                _model.rotation = Quaternion.Lerp(nextRotation, _model.rotation, 0.1f);
            }

            _animator.SetFloat(WalkSpeed, speedComponent.Speed.sqrMagnitude);
        }
    }
}