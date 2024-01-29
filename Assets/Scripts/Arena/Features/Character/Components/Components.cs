using ME.ECS;

namespace Scripts.Arena.Features.Components
{
    public struct CharacterTag : IStructComponent
    {
    }

    public struct HealthComponent : IStructComponent
    {
        public float Health;
        public float MaxHealth;
    }

    public struct ExperienceComponent : IStructComponent
    {
        public int Level;
        public float CurrentXP;
        public float ExperienceCapacity;
    }
}