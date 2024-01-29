using ME.ECS;
using UnityEngine;

namespace Scripts.Arena.Features.Components
{
    public struct PositionComponent : IStructComponent
    {
        public Vector3 Value;
    }

    public struct RotationComponent : IStructComponent
    {
        public Quaternion Value;
    }

    public struct SpeedComponent : IStructComponent
    {
        public float MaximumSpeed;
        public Vector3 Speed;
    }
}