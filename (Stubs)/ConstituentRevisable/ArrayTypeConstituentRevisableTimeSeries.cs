using System;

namespace Fofx
{
    [Serializable]
    public class ArrayTypeConstituentRevisableTimeSeries : ConstituentRevisableTimeSeriesGeneric<ConstituentArrayTypePoint, ArrayTypeValues>
    {
        public ArrayTypeConstituentRevisableTimeSeries()
        {
        }

        public ArrayTypeConstituentRevisableTimeSeries(DataManipulation.Interpolation interpolation, DataManipulation.Extrapolation extrapolation)
        {
        }
    }
}