using ME.ECS;
using UnityEngine;

namespace Arena.Physics.Components
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