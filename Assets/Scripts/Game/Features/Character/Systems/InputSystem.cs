using Extensions;
using Game.Shared.Services;
using Leopotam.Ecs;

namespace Game.Features.Character.Systems
{
    public class InputSystem : IEcsRunSystem
    {
        private EcsWorld _world;
        private IInputService _input;
        private EcsFilter<InputComponent> _filter;

        public InputSystem(IInputService input, EcsWorld world)
        {
            _input = input;
            _world = world;
        }

        public void Run()
        {
            if (_filter.TryGet1(out var inputComponent))
            {
                ref var component = ref inputComponent.Unref();
                component.Direction = _input.Axis;
            }
            else
            {
                _world.NewEntity()
                    .Replace(new InputComponent {Direction = _input.Axis});
            }
        }
    }
}