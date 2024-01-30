using UnityEngine;
using UnityEngine.AddressableAssets;

namespace Arena.StaticData
{
    [CreateAssetMenu(menuName = "Common/Arena information", fileName = "Level 0", order = 0)]
    public class ArenaInfo : ScriptableObject
    {
        [field: SerializeField] public AssetReference Scene { get; private set; }
    }
}