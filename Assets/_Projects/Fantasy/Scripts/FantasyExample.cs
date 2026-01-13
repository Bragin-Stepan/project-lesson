using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Project.Fantasy
{
    public class FantasyExample : MonoBehaviour
    {
        [SerializeField] private Transform _orkSpawnPoint;
        [SerializeField] private Transform _elfSpawnPoint;
        [SerializeField] private Transform _dragonSpawnPoint;
        
        [SerializeField] private List<OrkConfigSO> _orkConfigs;
        [SerializeField] private List<ElfConfigSO> _elfConfigs;
        [SerializeField] private List<DragonConfigSO> _dragonConfigs;
        
        private ObjectSpawner _spawner = new();

        private const int CharacterSpawnCount = 3;

        private void Awake()
        {
            for (int i = 0; i < CharacterSpawnCount; i++)
            {
               OrkConfigSO config = _orkConfigs[Random.Range(0, _orkConfigs.Count)];
                
               Ork ork = _spawner.SpawnToPoint(config.Prefab, _orkSpawnPoint);
               ork.Initialize(config);
            }
            
            for (int i = 0; i < CharacterSpawnCount; i++)
            {
                ElfConfigSO config = _elfConfigs[Random.Range(0, _elfConfigs.Count)];
                
                Elf elf = _spawner.SpawnToPoint(config.Prefab, _elfSpawnPoint);
                elf.Initialize(config);
            }
            
            for (int i = 0; i < CharacterSpawnCount; i++)
            {
                DragonConfigSO config = _dragonConfigs[Random.Range(0, _dragonConfigs.Count)];
                
                Dragon dragon = _spawner.SpawnToPoint(config.Prefab, _dragonSpawnPoint);
                dragon.Initialize(config);
            }
        }
    }
}