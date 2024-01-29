using UnityEngine;

namespace Arena.StaticData
{
    [CreateAssetMenu(menuName = "Common/Camera config", fileName = "CameraConfig", order = 0)]
    public class CameraConfig : ScriptableObject
    {
        [field: SerializeField] public float MaximumSpeed { get; private set; }
        [field: SerializeField, Range(2, 5)] public float Zoom { get; private set; }
        [field: SerializeField, Range(0, 75)] public float CameraAngle { get; private set; }
        [field: SerializeField] public float PositionThreshold { get; private set; }

        [field: SerializeField] public GameObject Prefab { get; private set; }
    }
}