using System;

namespace Fofx
{
    public interface ITimeSeriesIterator : IComparable<ITimeSeriesIterator>
    {
        DateTime StartDate { get; }
        DateTime EndDate { get; }
        DateTime Iaad { get; }
        int StartOffset { get; }
        int EndOffset { get; }
        bool AllRevisions { get; }
        int Revision { get; }
    }
}
