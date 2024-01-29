using ME.ECS;

namespace Game.Features.Events
{
    public struct TriggerEventComponent : IStructComponent, IComponentOneShot
    {
        public Entity Source;
        public Entity Target;
        public TriggerEventType Type;
    }

    public enum TriggerEventType
    {
        Enter,
        Stay,
        Exit
    }
}