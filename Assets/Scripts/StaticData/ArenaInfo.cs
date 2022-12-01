using UnityEditor;
using UnityEngine;

namespace StaticData
{
    [CreateAssetMenu(menuName = "Common/Arena information", fileName = "Level 0", order = 0)]
    public class ArenaInfo : ScriptableObject
    {
        [field: SerializeField] public SceneAsset Scene { get; }
    }
}