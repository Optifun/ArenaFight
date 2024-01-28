using Extensions;
using Game.Features.Tags;
using Game.Shared.Services;
using Leopotam.Ecs;

namespace Game.Features.Character.Systems
{
    public class InputSystem : IEcsRunSystem
    {
        private EcsWorld _world;
        private IInputService _input;
        private EcsFilter<EventTag> _filter;

        public InputSystem(IInputService input, EcsWorld world)
        {
            _input = input;
            _world = world;
        }

        public void Run()
        {
            foreach (var i in _filter)
            {
                ref var entity = ref _filter.GetEntity(i);
                entity.Replace(new InputComponent() {Direction = _input.Axis});
            }
        }
    }
}