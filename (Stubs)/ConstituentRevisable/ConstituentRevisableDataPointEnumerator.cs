using System;
using System.Collections;
using System.Collections.Generic;

namespace Fofx
{
    [Serializable]
    public class ConstituentRevisableDataPointEnumerator<T> : IEnumerator<KeyValuePair<DateTime, IDataPoint>>
      where T : class, IConstituentDataPoint
    {
        public ConstituentRevisableDataPointEnumerator(SortedList<DateTime, Revision<T>> items)
        {
        }

        public KeyValuePair<DateTime, IDataPoint> Current => throw new NotImplementedException();

        object IEnumerator.Current => throw new NotImplementedException();

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public bool MoveNext()
        {
            throw new NotImplementedException();
        }

        public void Reset()
        {
            throw new NotImplementedException();
        }
    }
}
