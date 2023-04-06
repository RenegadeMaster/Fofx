using System;

namespace Fofx
{
    [Serializable]
    public class CharacteristicTextPoint : ConstituentDataPoint<string>
    {
        public CharacteristicTextPoint(NonKeyedAttributeSet set) { }
    }

    [Serializable]
    public class StringCharacteristicRevisableTimeSeries : CharacteristicRevisableGeneric<CharacteristicTextPoint, string>
    {
    }
}