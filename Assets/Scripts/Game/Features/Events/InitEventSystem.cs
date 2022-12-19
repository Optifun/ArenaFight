using Game.Features.Tags;
using Leopotam.Ecs;

namespace Game.Features.Events
{
    public class InitEventSystem : IEcsInitSystem
    {
        private EcsWorld _world;

        public void Init()
        {
            _world.NewEntity().Get<EventTag>();
        }
    }
}