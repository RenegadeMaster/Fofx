using System;
using System.Collections.Generic;

namespace Fofx
{
    public static class DataManipulation
    {
        [Serializable]
        public enum Interpolation
        {
            Default = 0,
            None = 1,
            Forward = 2,
            Backward = 3,
            Linear = 4
        }

        [Serializable]
        public enum Extrapolation
        {
            Default = 0,
            None = 1,
            Forward = 2,
            ForwardsAndBackwards = 3,
            Days = 4,
            Linear = 5
        }

        public static string ToCSVString<T>(IEnumerable<T> items)
            => throw new NotImplementedException();
    }
}