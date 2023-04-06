using System;

namespace Fofx
{
    [Serializable]
    public class ConstituentTextArrayPoint : ConstituentDataPoint<string[]>
    {
        public ConstituentTextArrayPoint(DateTime declarationDate, DateTime valueDate, NonKeyedAttributeSet nonKeyedAttributeSet)
        {
        }
    }

    [Serializable]
    public class TextConstituentArrayTimeSeries : ConstituentRevisableTimeSeriesGeneric<ConstituentTextArrayPoint, string[]>
    {
        public TextConstituentArrayTimeSeries()
        {
        }

        public TextConstituentArrayTimeSeries(DataManipulation.Interpolation interpolation, DataManipulation.Extrapolation extrapolation)
        {
        }
    }
}