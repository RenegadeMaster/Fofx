using System;

namespace Fofx
{
    [Serializable]
    public class ConstituentTextPoint : ConstituentDataPoint<String>
    {
        public ConstituentTextPoint(DateTime declarationDate, DateTime valueDate, NonKeyedAttributeSet nonKeyedAttributeSet)
        {
        }
    }

    [Serializable]
    public class TextConstituentRevisableTimeSeries : ConstituentRevisableTimeSeriesGeneric<ConstituentTextPoint, string>
    {
        public TextConstituentRevisableTimeSeries()
        {
        }

        public TextConstituentRevisableTimeSeries(DataManipulation.Interpolation interpolation, DataManipulation.Extrapolation extrapolation)
        {
        }
    }
}