using UnityEngine;

namespace Project.Fantasy
{
    public abstract class EnemyConfigSO : ScriptableObject
    {
        [field:SerializeField] public float MoveSpeed { get; private set; }
        [field:SerializeField] public float Mana { get; private set; }
        
        [field:SerializeField] public int Strength { get; private set; }
        [field:SerializeField] public int Dexterity { get; private set; }
        [field:SerializeField] public int Intelligence { get; private set; }
    }
}