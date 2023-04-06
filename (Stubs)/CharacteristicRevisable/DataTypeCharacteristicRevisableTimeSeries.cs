using System;

namespace Fofx
{
    [Serializable]
    public class CharacteristicDataTypePoint : ConstituentDataPoint<DataTypeValues>
    {
    }

    [Serializable]
    public class DataTypeCharacteristicRevisableTimeSeries : CharacteristicRevisableGeneric<CharacteristicDataTypePoint, DataTypeValues>
    {
    }
}