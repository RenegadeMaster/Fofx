using System;

namespace Fofx
{
    [Serializable]
    public class TimeSeriesDescriptor : IComparable<TimeSeriesDescriptor>, IComparable
    {
        public SourceDescriptor Source { get; set; }
        public DataManipulation.Interpolation Interpolation { get; set; }
        public DataManipulation.Extrapolation Extrapolation { get; set; }
        public int ValueDefinition { get; set; }


        public int CompareTo(TimeSeriesDescriptor other)
        {
            throw new NotImplementedException();
        }

        public int CompareTo(object obj)
        {
            throw new NotImplementedException();
        }
    }

    [Serializable]
    public class RelationshipSeriesDescriptor : IComparable<RelationshipSeriesDescriptor>, IComparable
    {
        public int CompareTo(RelationshipSeriesDescriptor other)
        {
            throw new NotImplementedException();
        }

        public int CompareTo(object obj)
        {
            throw new NotImplementedException();
        }
    }
}