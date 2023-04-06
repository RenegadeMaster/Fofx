using System;

namespace Fofx
{
    [Serializable]
    public class ConstituentNumericArrayPoint : ConstituentDataPoint<double[]>
    {
        public ConstituentNumericArrayPoint(DateTime declarationDate, DateTime valueDate, NonKeyedAttributeSet nonKeyedAttributeSet)
        {
        }
    }

    [Serializable]
    public class NumericConstituentArrayTimeSeries : ConstituentRevisableTimeSeriesGeneric<ConstituentNumericArrayPoint, double[]>
    {
        public NumericConstituentArrayTimeSeries()
        {
        }

        public NumericConstituentArrayTimeSeries(DataManipulation.Interpolation interpolation, DataManipulation.Extrapolation extrapolation)
        {
        }
    }
}