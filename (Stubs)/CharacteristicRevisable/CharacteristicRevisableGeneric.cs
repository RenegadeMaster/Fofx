using System;
using System.Collections;
using System.Collections.Generic;

namespace Fofx
{
    [Serializable]
    public abstract class CharacteristicRevisableGeneric<T, Y> : ICharacteristicRevisableTimeSeries
      where T : class, IConstituentDataPoint
    {
        public void Add<TPoint>(TPoint point) => throw new NotImplementedException();
        public int Count => throw new NotImplementedException();

        public IEnumerable<DateTime> Dates => throw new NotImplementedException();

        public DateTime StartDate => throw new NotImplementedException();

        public DateTime EndDate => throw new NotImplementedException();

        public DateTime CachedStartDate { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public DateTime CachedEndDate { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public DataManipulation.Interpolation Interpolation => throw new NotImplementedException();

        public DataManipulation.Extrapolation Extrapolation => throw new NotImplementedException();

        public TimeSeriesType Type => throw new NotImplementedException();

        public Type ElementType => throw new NotImplementedException();

        public TimeSeriesDataType ValueType => throw new NotImplementedException();

        public void Add(IEntityDescriptor entity, DateTime valueDate, DateTime declarationDate, object value, NonKeyedAttributeSet nonKeyedAttributeSet)
        {
            throw new NotImplementedException();
        }

        public bool AddSafe(IEntityDescriptor entity, DateTime valueDate, DateTime declarationDate, object value)
        {
            throw new NotImplementedException();
        }

        public void AddValue(IEntityDescriptor entityCode, object value, NonKeyedAttributeSet nonKeyedAttributeSet = null)
        {
            throw new NotImplementedException();
        }

        public void Compact()
        {
            throw new NotImplementedException();
        }

        public bool ContainsDate(DateTime key)
        {
            throw new NotImplementedException();
        }

        public bool ContainsDates(IList<DateTime> dates)
        {
            throw new NotImplementedException();
        }

        public int FindNextDate(DateTime lDate)
        {
            throw new NotImplementedException();
        }

        public int FindPreviousDate(DateTime lDate)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<IEntityDescriptor> GetConstituents(DateTime startDate, DateTime endDate)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<IEntityDescriptor> GetConstituents(DateTime date)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<IEntityDescriptor> GetConstituents()
        {
            throw new NotImplementedException();
        }

        public DateTime GetDate(int index)
        {
            throw new NotImplementedException();
        }

        public IEnumerator<KeyValuePair<DateTime, IDataPoint>> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        public DateTime GetNextDate(DateTime lDate)
        {
            throw new NotImplementedException();
        }

        public IConstituentDataPoint GetPoint(DateTime valueDate, DateTime declarationDate, NonKeyedAttributeSet nonKeyedAttributeSet = null)
        {
            throw new NotImplementedException();
        }

        public DateTime GetPreviousDate(DateTime lDate)
        {
            throw new NotImplementedException();
        }

        public IDataPoint GetValue(DateTime date)
        {
            throw new NotImplementedException();
        }

        public ITimeSeries GetView(ITimeSeriesIterator iterator, DataManipulation.Interpolation interpolation, DataManipulation.Extrapolation extrapolation, IConstituentTimeSeries constituents, NonKeyedAttributeSet nonKeyedAttributes)
        {
            throw new NotImplementedException();
        }

        public ITimeSeries GetView(ITimeSeriesIterator iterator, DataManipulation.Interpolation interpolation, DataManipulation.Extrapolation extrapolation, NonKeyedAttributeSet nonKeyAttributes)
        {
            throw new NotImplementedException();
        }

        public bool IsInRange(ITimeSeriesIterator iterator)
        {
            throw new NotImplementedException();
        }

        public bool IsValidValue(object value)
        {
            throw new NotImplementedException();
        }

        public bool TryGetValue(DateTime date, out IDataPoint value)
        {
            throw new NotImplementedException();
        }

        public bool TryMerge(ITimeSeries mergeMe)
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
