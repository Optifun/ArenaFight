using UnityEngine;

namespace Arena.StaticData
{
    [CreateAssetMenu(menuName = "Common/Unit info", fileName = "Unit", order = 0)]
    public class EnemyInfo : ScriptableObject
    {
        public UnitStats Stats;
        public GameObject UnitPrefab;
    }
}