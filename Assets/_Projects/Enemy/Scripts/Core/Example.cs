using System;
using System.Collections.Generic;
using UnityEngine;

namespace Project.Enemy
{
    public class Example: MonoBehaviour
    {
        [SerializeField] private Enemy _enemyOnePrefab;
        [SerializeField] private Enemy _enemyTwoPrefab;
        [SerializeField] private Enemy _enemyThreePrefab;
        
        [SerializeField] private Transform _spawnPoint;
        [SerializeField] private int _maxEnemiesCount = 10;

        private DestroyService _destroyService;
        private ObjectSpawner<Enemy> _spawner;

        private void Awake()
        {
            _destroyService = new DestroyService(_maxEnemiesCount);
            _spawner = new ObjectSpawner<Enemy>();
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                Enemy enemy = _spawner.SpawnToPoint(_enemyOnePrefab, _spawnPoint.position);
                
                _destroyService.Register(
                    enemy,
                    new List<ICauseDestroy>()
                    {
                        new LifetimeIsCauseDestroy(enemy, 3, this)
                    });
            }
        
            
            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                Enemy enemy = _spawner.SpawnToPoint(_enemyTwoPrefab, _spawnPoint.position);

                _destroyService.Register(
                    enemy,
                    new List<ICauseDestroy>()
                    {
                        new DeathIsCauseDestroy(enemy),
                        // new OverLimitIsCauseDestroy()
                    });
            }
            
            if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                Enemy enemy = _spawner.SpawnToPoint(_enemyThreePrefab, _spawnPoint.position);
                
                _destroyService.Register(
                    enemy,
                    new List<ICauseDestroy>()
                    {
                        new OverLimitIsCauseDestroy()
                    });
            }

            Debug.Log("[DestroyService] Count: " + _destroyService.Count);
        }
    }
}