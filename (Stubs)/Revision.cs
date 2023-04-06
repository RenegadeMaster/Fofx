using System;
using System.Collections.Generic;

namespace Fofx
{
    [Serializable]
    public class Revision<T> : IEnumerable<KeyValuePair<DateTime, T>>
      where T : class, IDataPoint
    {
        internal Revision(DateTime valueDate, int capacity)
            => throw new NotImplementedException();

        public Revision(DateTime valueDate)
            => throw new NotImplementedException();

        public DateTime ValueDate
            => throw new NotImplementedException();

        public DateTime Min
            => throw new NotImplementedException();

        public DateTime Max
            => throw new NotImplementedException();

        public IList<DateTime> Dates
            => throw new NotImplementedException();

        public int Count
            => throw new NotImplementedException();

        public void Add(DateTime date, T val)
            => throw new NotImplementedException();

        public bool TryGetValue(DateTime iaad, out T value)
            => throw new NotImplementedException();

        public T GetValue(DateTime declarationDate)
            => throw new NotImplementedException();

        internal Revision<T> Filter(NonKeyedAttributeSet nonKeyAttributes)
            => throw new NotImplementedException();

        public T this[DateTime declarationDate]
            => throw new NotImplementedException();

        public bool Contains(DateTime date)
            => throw new NotImplementedException();

        #region IEnumerable<KeyValuePair<DateTime,T>> Members

        public IEnumerator<KeyValuePair<DateTime, T>> GetEnumerator()
            => throw new NotImplementedException();

        #endregion

        #region IEnumerable Members

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
            => throw new NotImplementedException();

        #endregion
    }
}