using System;

namespace Project.Enemy
{
    public interface ICauseDestroy
    {
        event Action<IDestroyable> Destroyed;
    }
}