using UnityEngine;

namespace Project.Fantasy
{
    [CreateAssetMenu(fileName = "Ork Data", menuName = "Game/Fantasy/Ork Data")]
    public class OrkConfigSO : CharacterConfigSO
    {
        [field:SerializeField] public Ork Prefab { get; private set; }
    }
}