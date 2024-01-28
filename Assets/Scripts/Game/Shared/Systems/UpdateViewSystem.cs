using Game.Shared.Components;
using Leopotam.Ecs;

namespace Game.Shared.Systems
{
    public class UpdateViewSystem : IEcsRunSystem
    {
        private EcsFilter<ViewRef> _filter;

        public void Run()
        {
            foreach (var i in _filter)
            {
                ref var viewRef = ref _filter.Get1(i);
                viewRef.EntityView.OnViewStateUpdated();
            }
        }
    }
}