using System;

namespace Fofx
{
    [Serializable]
    public class CharacteristicDatePoint : ConstituentDataPoint<DateTime?>
    {
        public CharacteristicDatePoint(NonKeyedAttributeSet set) { }
    }

    [Serializable]
    public class DateCharacteristicRevisableTimeSeries : CharacteristicRevisableGeneric<CharacteristicDatePoint, DateTime?>
    {
    }
}