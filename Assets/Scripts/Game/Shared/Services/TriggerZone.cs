using Game.Features.Events;
using Leopotam.Ecs;
using UnityEngine;

namespace Game.Shared.Services
{
    public class TriggerZone<TTag> : MonoBehaviour where TTag : struct
    {
        private EntityReference _entity;
        private EcsWorld _world;

        public void Init(EntityReference target, EcsWorld world)
        {
            _entity = target;
            _world = world;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (!other.TryGetComponent<EntityReference>(out var reference))
                return;

            TryRegisterEvent(reference, TriggerEventType.Enter);
        }

        private void OnTriggerStay(Collider other)
        {
            if (!other.TryGetComponent<EntityReference>(out var reference))
                return;

            TryRegisterEvent(reference, TriggerEventType.Stay);
        }

        private void OnTriggerExit(Collider other)
        {
            if (!other.TryGetComponent<EntityReference>(out var reference))
                return;

            TryRegisterEvent(reference, TriggerEventType.Exit);
        }

        private void TryRegisterEvent(EntityReference reference, TriggerEventType eventType)
        {
            if (reference.Entity.Has<TTag>())
                _world.NewEntity().Replace(new TriggerEventComponent
                {
                    Source = _entity.Entity,
                    Target = reference.Entity,
                    Type = eventType
                });
        }
    }
}