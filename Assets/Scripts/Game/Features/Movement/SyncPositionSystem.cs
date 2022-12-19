using Game.Shared.Components;
using Leopotam.Ecs;
using UnityEngine;

namespace Game.Features.Movement
{
    public class SyncPositionSystem : IEcsRunSystem
    {
        private EcsFilter<PositionComponent, UnityObject<Transform>> _filter;

        public void Run()
        {
            foreach (var i in _filter)
            {
                ref var position = ref _filter.Get1(i);
                ref var transform = ref _filter.Get2(i);
                transform.Value.position = position.Position;
            }
        }

        private static float FrameIndependent(float k) =>
            1 - Mathf.Pow(k, Time.fixedDeltaTime);
    }
}