using System;

namespace Fofx
{
    [Serializable]
    public class CharacteristicNumericPoint : ConstituentDataPoint<double?>
    {
        public CharacteristicNumericPoint(NonKeyedAttributeSet set) { }
    }

    [Serializable]
    public class NumericCharacteristicRevisableTimeSeries : CharacteristicRevisableGeneric<CharacteristicNumericPoint, double?>
    {
    }
}