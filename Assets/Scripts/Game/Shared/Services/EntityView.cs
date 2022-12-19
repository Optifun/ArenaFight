using Leopotam.Ecs;
using UnityEngine;

namespace Game.Shared.Services
{
    public abstract class EntityView : MonoBehaviour, IEntityView
    {
        protected EcsEntity Entity;

        public void AttachEntity(EcsEntity entity)
        {
            Entity = entity;
        }

        public abstract void OnViewStateUpdated();
    }
}