using System;

namespace Fofx
{
    [Serializable]
    public class TimeSeriesKey : ITimeSeriesKey, IComparable<ITimeSeriesKey>, IComparable<TimeSeriesKey>
    {
        public TimeSeriesDescriptor TimeSeries { get; }

        public IEntityDescriptor Entity => throw new NotImplementedException();

        public string DataType => throw new NotImplementedException();

        public DataManipulation.Interpolation Interpolation => throw new NotImplementedException();

        public DataManipulation.Extrapolation Extrapolation => throw new NotImplementedException();

        public ITimeSeriesKey Clone(DataManipulation.Interpolation interpolation, DataManipulation.Extrapolation extrapolation)
        {
            throw new NotImplementedException();
        }

        public int CompareTo(ITimeSeriesKey other)
        {
            throw new NotImplementedException();
        }

        public int CompareTo(TimeSeriesKey other)
        {
            throw new NotImplementedException();
        }

        public bool Match(ITimeSeriesKey s)
        {
            throw new NotImplementedException();
        }

        public bool MatchExInterp(ITimeSeriesKey key)
        {
            throw new NotImplementedException();
        }

        public bool SimpleEquals(ITimeSeriesKey other)
        {
            throw new NotImplementedException();
        }

        public bool SimpleEqualsIgnoreNonKey(ITimeSeriesKey other)
        {
            throw new NotImplementedException();
        }

        public int SimpleGetHashCode()
        {
            throw new NotImplementedException();
        }
    }
}
