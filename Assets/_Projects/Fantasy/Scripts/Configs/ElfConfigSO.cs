using UnityEngine;

namespace Project.Fantasy
{
    [CreateAssetMenu(fileName = "Elf Data", menuName = "Game/Fantasy/Elf Data")]
    public class ElfConfigSO : EnemyConfigSO
    {
        [field:SerializeField] public Elf Prefab { get; private set; }
    }
}