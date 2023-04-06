using System;

namespace Fofx
{
    [Serializable]
    public class ConstituentDateArrayPoint : ConstituentDataPoint<DateTime[]>
    {
        public ConstituentDateArrayPoint(DateTime declarationDate, DateTime valueDate, NonKeyedAttributeSet nonKeyedAttributeSet)
        {
        }
    }

    [Serializable]
    public class DateConstituentArrayTimeSeries : ConstituentRevisableTimeSeriesGeneric<ConstituentDateArrayPoint, DateTime[]>
    {
        public DateConstituentArrayTimeSeries()
        {
        }

        public DateConstituentArrayTimeSeries(DataManipulation.Interpolation interpolation, DataManipulation.Extrapolation extrapolation)
        {
        }
    }
}