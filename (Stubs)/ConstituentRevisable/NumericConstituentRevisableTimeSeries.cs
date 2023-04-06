using System;

namespace Fofx
{
    [Serializable]
    public class ConstituentNumericPoint : ConstituentDataPoint<Double?>
    {
        public ConstituentNumericPoint(DateTime declarationDate, DateTime valueDate, NonKeyedAttributeSet nonKeyedAttributeSet)
        {
        }
    }

    [Serializable]
    public class NumericConstituentRevisableTimeSeries : ConstituentRevisableTimeSeriesGeneric<ConstituentNumericPoint, double?>
    {
        public NumericConstituentRevisableTimeSeries()
        {
        }

        public NumericConstituentRevisableTimeSeries(DataManipulation.Interpolation interpolation, DataManipulation.Extrapolation extrapolation)
        {
        }
    }
}