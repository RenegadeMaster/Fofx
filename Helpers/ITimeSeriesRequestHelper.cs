using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;

namespace Fofx
{
  public interface ITimeSeriesRequestHelper : IComparable<ITimeSeriesRequestHelper>, IComparable
  {
    ITimeSeries CreateNew(ITimeSeriesIterator itearator, TimeSeriesDescriptor factor);

    SortedList<ITimeSeriesKey, ITimeSeries> ReadTimeSeries(IEnumerable<TimeSeriesKey> dbCallRequired, DatabaseRequestArgs args, TimeSeriesDatabaseContext requester);
  }
}
