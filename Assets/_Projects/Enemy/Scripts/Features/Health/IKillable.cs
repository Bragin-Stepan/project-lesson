using System;

namespace Project.Enemy
{
    public interface IKillable
    {
        event Action<IKillable> Dead;
        void Kill();
    }
}