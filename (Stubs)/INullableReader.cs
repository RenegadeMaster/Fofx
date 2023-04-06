using System;

namespace Fofx
{
    public interface INullableReader : IDisposable
    {
        bool Read();

        bool GetBoolean(string name);
        Nullable<bool> GetNullableBoolean(string name);
        byte GetByte(string name);
        Nullable<byte> GetNullableByte(string name);
        char GetChar(string name);
        Nullable<char> GetNullableChar(string name);
        DateTime GetDateTime(string name);
        Nullable<DateTime> GetNullableDateTime(string name);
        decimal GetDecimal(string name);
        Nullable<Decimal> GetNullableDecimal(string name);
        double GetDouble(string name);
        Nullable<double> GetNullableDouble(string name);
        float GetFloat(string name);
        Nullable<float> GetNullableFloat(string name);
        Guid GetGuid(string name);
        Nullable<Guid> GetNullableGuid(string name);
        short GetInt16(string name);
        Nullable<short> GetNullableInt16(string name);
        int GetInt32(string name);
        Nullable<int> GetNullableInt32(string name);
        long GetInt64(string name);
        Nullable<long> GetNullableInt64(string name);
        string GetString(string name);
        string GetNullableString(string name);
        object GetValue(string name);
        bool IsDBNull(string name);

        bool GetBoolean(int index);
        Nullable<bool> GetNullableBoolean(int index);
        byte GetByte(int index);
        Nullable<byte> GetNullableByte(int index);
        char GetChar(int index);
        Nullable<char> GetNullableChar(int index);
        DateTime GetDateTime(int index);
        Nullable<DateTime> GetNullableDateTime(int index);
        decimal GetDecimal(int index);
        Nullable<Decimal> GetNullableDecimal(int index);
        double GetDouble(int index);
        Nullable<double> GetNullableDouble(int index);
        float GetFloat(int index);
        Nullable<float> GetNullableFloat(int index);
        Guid GetGuid(int index);
        Nullable<Guid> GetNullableGuid(int index);
        short GetInt16(int index);
        Nullable<short> GetNullableInt16(int index);
        int GetInt32(int index);
        Nullable<int> GetNullableInt32(int index);
        long GetInt64(int index);
        Nullable<long> GetNullableInt64(int index);
        string GetString(int index);
        string GetNullableString(int index);
        object GetValue(int index);
        bool IsDBNull(int index);

    }
}