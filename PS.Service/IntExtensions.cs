using System;

namespace PS.Service
{
    public static class IntExtensions
    {
        public static bool IsGreatThan(this int x, int y)
        {
            return x > y;
        }
    }
}
