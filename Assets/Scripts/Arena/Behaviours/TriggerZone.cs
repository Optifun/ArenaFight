using Arena.Events.Components;
using ME.ECS;
using UnityEngine;

namespace Arena.Behaviours
{
    public class TriggerZone<TTag> : MonoBehaviour where TTag : struct, IComponent
    {
        private EntityReference _entity;
        private World _world;

        public void Init(EntityReference target, World world)
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
            var source = _world.GetEntityById(_entity.EntityId);
            var target = _world.GetEntityById(reference.EntityId);
            if (source.Has<TTag>())
            {
                _world.AddEntity(flags: EntityFlag.OneShot).Set(new TriggerEventComponent
                {
                        Source = source,
                        Target = target,
                        Type = eventType
                });
            }
        }
    }
}