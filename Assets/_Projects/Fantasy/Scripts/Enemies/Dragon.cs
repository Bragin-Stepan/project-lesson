using UnityEngine;

namespace Project.Fantasy
{
    public  class Dragon : Enemy
    {

        public void Initialize(DragonConfigSO config)
        {
            Debug.Log($"Dragon skill: {config.SkillName}");
        }
    }
}