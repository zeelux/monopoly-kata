using System;

namespace Monopoly.DiceClasses
{
    public interface IDice
    {
        int DoublesCount { get; }
        bool IsDoubles { get; }
        int Roll();

        void ResetDoublesCount();
    }
}
