using UnityEngine;

namespace Arena.StaticData
{
    [CreateAssetMenu(menuName = "Common/Character info", fileName = "Character", order = 0)]
    public class CharacterInfo : ScriptableObject
    {
        public GameObject CharacterPrefab;
        public UnitStats BaseStats;
        public int[] LevelProgression;
    }
}