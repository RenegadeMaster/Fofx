using System;

namespace Fofx
{
    [Serializable]
    public class ConstituentDatePoint : ConstituentDataPoint<DateTime?>
    {
        public ConstituentDatePoint(DateTime declarationDate, DateTime valueDate, NonKeyedAttributeSet nonKeyedAttributeSet)
        {
        }
    }

    [Serializable]
    public class DateConstituentRevisableTimeSeries : ConstituentRevisableTimeSeriesGeneric<ConstituentDatePoint, DateTime?>
    {
        public DateConstituentRevisableTimeSeries()
        {
        }

        public DateConstituentRevisableTimeSeries(DataManipulation.Interpolation interpolation, DataManipulation.Extrapolation extrapolation)
        {
        }
    }
}