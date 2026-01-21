using System;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Project.Fantasy
{
    public class EnemySpawner
    {
        public Enemy SpawnToPoint(EnemyConfigSO config, Transform spawnPoint)
        {
            switch (config)
            {
                case OrkConfigSO orkConfig:
                    Ork ork = Object.Instantiate(orkConfig.Prefab, spawnPoint.position, Quaternion.identity, null);
                    ork.Initialize(orkConfig);
                    return ork;
                    
                case ElfConfigSO elfConfig:
                    Elf elf = Object.Instantiate(elfConfig.Prefab, spawnPoint.position, Quaternion.identity, null);
                    elf.Initialize(elfConfig);
                    return elf;
                
                case DragonConfigSO dragonConfig:
                    Dragon dragon = Object.Instantiate(dragonConfig.Prefab, spawnPoint.position, Quaternion.identity, null);
                    dragon.Initialize(dragonConfig);
                    return dragon;
                
                default:
                    throw new ArgumentOutOfRangeException(nameof(config), config, null);
            }
        }
    }
}