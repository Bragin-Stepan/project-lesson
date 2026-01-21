using UnityEngine;

namespace Project.Fantasy
{
    [CreateAssetMenu(fileName = "Dragon Data", menuName = "Game/Fantasy/Dragon Data")]
    public class DragonConfigSO : EnemyConfigSO
    {
        [field:SerializeField] public Dragon Prefab { get; private set; }
        
        [field:SerializeField] public string SkillName { get; private set; } = "Fireball";
    }
}