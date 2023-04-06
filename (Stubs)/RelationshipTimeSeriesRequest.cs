using System;

namespace Fofx
{
    [Serializable]
    public class RelationshipTimeSeriesRequest : IComparable, IComparable<RelationshipTimeSeriesRequest>
    {
        public RelationshipDescriptor Relationship { get; }
        public TimeSeriesDescriptor TimeSeries { get; }
        public ITimeSeriesIterator Iterator { get; }

        public int CompareTo(object obj)
        {
            throw new NotImplementedException();
        }

        public int CompareTo(RelationshipTimeSeriesRequest other)
        {
            throw new NotImplementedException();
        }
    }
}