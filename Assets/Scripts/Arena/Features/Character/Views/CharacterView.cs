using Arena.Physics.Components;
using ME.ECS;
using ME.ECS.Views.Providers;
using UnityEngine;

namespace Arena.Character.Views
{
    public class CharacterView : MonoBehaviourView
    {
        public override bool applyStateJob => true;
        [SerializeField] private Animator _animator;
        [SerializeField] private Transform _model;

        private static readonly int WalkSpeed = Animator.StringToHash("WalkSpeed");

        public override void ApplyState(float deltaTime, bool immediately)
        {
            ref readonly var speed = ref entity.Read<SpeedComponent>();
            ref readonly var position = ref entity.Read<PositionComponent>();
            if (speed.Speed != Vector3.zero)
            {
                var nextRotation = Quaternion.LookRotation(speed.Speed);
                _model.rotation = Quaternion.Lerp(nextRotation, _model.rotation, 0.1f);
            }

            _animator.SetFloat(WalkSpeed, speed.Speed.sqrMagnitude);
            transform.position = position.Value;
        }

        private static float FrameIndependent(float k) =>
                1 - Mathf.Pow(k, Time.fixedDeltaTime);
    }
}