using System;

namespace Project.Enemy
{
    public class OverLimitIsCauseDestroy: ICauseDestroy
    {
        public event Action<IDestroyable> Destroyed;
    }
}