using UnityEngine;

namespace Assets.Scripts.AbilitySystem
{
    [CreateAssetMenu(fileName = nameof(BaseAbilityStats), menuName = nameof(ScriptableObject) + "/" + nameof(BaseAbilityStats))]
    public class BaseAbilityStats : ScriptableObject
    {
        [field: SerializeField] public string Name { get; set; } = "Ability";
        [field: SerializeField] public int Cost { get; set; } = 1;
        [field: SerializeField] public int Level { get; set; } = 1;
        [field: SerializeField] public float Ratio { get; set; } = 1;
        [field: SerializeField] public float UpLevelRatioGrowth { get; set; } = 1.1f;
        [field: SerializeField] public float UpLevelCostGrowth { get; set; } = 1.2f;
    }
}
