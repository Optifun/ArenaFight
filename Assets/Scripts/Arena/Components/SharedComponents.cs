using ME.ECS;
using UnityEngine;

namespace Scripts.Arena.Components
{
    public struct PlayerId : IStructComponent
    {
        public int Id;
    }

    public struct UnityTransform : IStructComponent
    {
        public Transform Value;
    }
}