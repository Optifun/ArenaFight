using Leopotam.Ecs;
using UnityEngine;

namespace Game.Features.Movement
{
    public class ApplySpeedSystem : IEcsRunSystem
    {
        private EcsFilter<PositionComponent, SpeedComponent> _filter;

        public void Run()
        {
            foreach (var i in _filter)
            {
                ref var position = ref _filter.Get1(i);
                ref var speed = ref _filter.Get2(i);
                position.Position += speed.Speed * Time.fixedTime;
            }
        }
    }
}