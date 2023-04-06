using System;

namespace Fofx
{
    public interface ITimeSeriesKey : IComparable<ITimeSeriesKey>
    {
        IEntityDescriptor Entity { get; }

        string DataType { get; }

        bool Match(ITimeSeriesKey s);

        DataManipulation.Interpolation Interpolation { get; }

        DataManipulation.Extrapolation Extrapolation { get; }

        int SimpleGetHashCode();

        bool SimpleEquals(ITimeSeriesKey other);

        bool SimpleEqualsIgnoreNonKey(ITimeSeriesKey other);

        //Used in TimeSeriesCollection.FilterCollection to clone inter/extra-polation
        ITimeSeriesKey Clone(DataManipulation.Interpolation interpolation, DataManipulation.Extrapolation extrapolation);

        bool MatchExInterp(ITimeSeriesKey key);
    }
}
