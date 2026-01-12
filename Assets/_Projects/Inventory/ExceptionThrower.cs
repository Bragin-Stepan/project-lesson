using System;

namespace Project.Inventory
{
    public static class ExceptionThrower
    {
        public static void MustGreaterZero()
        {
            throw new ArgumentException("Count must be greater than zero");
        }
    }
}