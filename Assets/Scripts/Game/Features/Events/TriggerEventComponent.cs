using Leopotam.Ecs;

namespace Game.Features.Events
{
    public struct TriggerEventComponent
    {
        public EcsEntity Source;
        public EcsEntity Target;
        public TriggerEventType Type;
    }
}