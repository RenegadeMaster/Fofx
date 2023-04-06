using System;

namespace Fofx
{
    [Serializable]
    public class DataTypeConstituentRevisableTimeSeries : ConstituentRevisableTimeSeriesGeneric<ConstituentDataTypePoint, DataTypeValues>
    {
        public DataTypeConstituentRevisableTimeSeries()
        {
        }

        public DataTypeConstituentRevisableTimeSeries(DataManipulation.Interpolation interpolation, DataManipulation.Extrapolation extrapolation)
        {
        }
    }
}
