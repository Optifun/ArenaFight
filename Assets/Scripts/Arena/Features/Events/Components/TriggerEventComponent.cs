using ME.ECS;

namespace Arena.Events.Components
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