using UnityEngine;

namespace StaticData
{
    [CreateAssetMenu(menuName = "Common/Camera config", fileName = "CameraConfig", order = 0)]
    public class CameraConfig : ScriptableObject
    {
        [field: SerializeField] public float MaximumSpeed { get; private set; }
        [field: SerializeField] public float Zoom { get; private set; }
        [field: SerializeField] public float PositionThreshold { get; private set; }

        [field: SerializeField] public Camera Prefab { get; private set; }
    }
}