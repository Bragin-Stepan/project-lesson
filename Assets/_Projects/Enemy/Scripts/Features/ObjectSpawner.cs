using System;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Project.Enemy
{
    public class ObjectSpawner<T> where T: MonoBehaviour
    {
        public T SpawnToPoint(T targetPrefab, Vector3 point) 
            => Object.Instantiate(targetPrefab, point, Quaternion.identity, null);
    }
}