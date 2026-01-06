using System;
using UnityEngine;

namespace Project.Enemy
{
    public class KillAreaTrigger: MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out IKillable target))
                target.Kill();
        }
    }
}