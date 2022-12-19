using Game.Shared.Services;

namespace Game.Shared.Components
{
    public struct ViewRef
    {
        public IEntityView EntityView;

        public ViewRef(IEntityView view) =>
            EntityView = view;
    }
}