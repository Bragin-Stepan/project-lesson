using UnityEngine;

namespace Project.Fantasy
{
    public class ObjectSpawner
    {
        public T SpawnToPoint<T>(T prefab, Transform spawnPoint) where T : Object
            => Object.Instantiate(prefab, spawnPoint.position, Quaternion.identity, null);
    }
}