using UnityEngine;

namespace Project.Fantasy
{
    [CreateAssetMenu(fileName = "Elf Data", menuName = "Game/Fantasy/Elf Data")]
    public class ElfConfigSO : CharacterConfigSO
    {
        [field:SerializeField] public Elf Prefab { get; private set; }
    }
}