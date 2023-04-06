using System;

namespace Fofx
{
    [Serializable]
    public class TimeSeriesRequest : IComparable, IComparable<TimeSeriesRequest>
    {
        public ITimeSeriesIterator Iterator { get; }
        public TimeSeriesDescriptor TimeSeries { get; }

        public int CompareTo(object obj)
        {
            throw new NotImplementedException();
        }

        public int CompareTo(TimeSeriesRequest other)
        {
            throw new NotImplementedException();
        }
    }
}
