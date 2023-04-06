using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Fofx
{
    public static class DataAccess
    {
        public static INullableReader GetDataReader(string storedProcedureName, IEnumerable<SqlParameter> parameters)
            => throw new NotImplementedException();
    }
}
