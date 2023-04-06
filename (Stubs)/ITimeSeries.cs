using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Fofx
{
    public enum TimeSeriesDataType
    {
        Numeric = 'N',
        Text = 'T',
        Enum = 'E',
        [Browsable(false)]
        Code = 'C',
        Date = 'D',
        UserDefined = 'U',
        [Browsable(false)]
        Unknown = 'X',
        [Browsable(false)]
        CompoundCode = 'Q'
    }

    public enum TimeSeriesType
    {
        NumericRevisable,
        NumericSnapshot,
        NumericConstituentRevisable,
        StringRevisable,
        StringSnapshot,
        StringConstituentRevisable,
        DateRevisable,
        DateSnapshot,
        DataTypeRevisable,
        DataTypeSnapshot,
        DateConstituentRevisable,
        Hierarchy,
        Constituents,
        StringCharacteristic,
        NumericCharacteristic,
        DateCharacteristic,
        ArrayTypeRevisable
    }

    [Flags]
    public enum TimeSeriesProps
    {
        None = 0,
        Snapshot = 1,
        Characteristic = 2,
        Array = 4
    }

    [Flags]
    public enum RelationshipProps
    {
        None = 0,
        List = 1,
        Reversed = 2
    }

    public interface ITimeSeries : IEnumerable<KeyValuePair<DateTime, IDataPoint>>
    {
        int Count { get; }

        IEnumerable<DateTime> Dates { get; }

        DateTime StartDate { get; }

        DateTime EndDate { get; }

        DateTime CachedStartDate { get; set; }

        DateTime CachedEndDate { get; set; }

        DataManipulation.Interpolation Interpolation { get; }

        DataManipulation.Extrapolation Extrapolation { get; }

        void Compact();

        int FindNextDate(DateTime lDate);

        int FindPreviousDate(DateTime lDate);

        DateTime GetNextDate(DateTime lDate);

        DateTime GetPreviousDate(DateTime lDate);

        DateTime GetDate(int index);

        IDataPoint GetValue(DateTime date);

        /// <summary>Try to get the value with out interpolation</summary>
        bool TryGetValue(DateTime date, out IDataPoint value);

        TimeSeriesType Type { get; }

        Type ElementType { get; }

        TimeSeriesDataType ValueType { get; }

        bool ContainsDates(IList<DateTime> dates);

        bool ContainsDate(DateTime key);

        ITimeSeries GetView(ITimeSeriesIterator iterator, DataManipulation.Interpolation interpolation, DataManipulation.Extrapolation extrapolation, NonKeyedAttributeSet nonKeyAttributes);

        bool TryMerge(ITimeSeries mergeMe);

        bool IsInRange(ITimeSeriesIterator iterator);
    }
}
