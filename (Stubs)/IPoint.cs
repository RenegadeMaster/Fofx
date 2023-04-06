using System;
using System.Collections.Generic;

namespace Fofx
{
    public interface IDataPoint
    {
        DateTime DeclarationDate { get; }
        DateTime ValueDate { get; }
        object Value { get; }
        IDataPoint Shift(DateTime valueDate, DateTime declarationDate);
        NonKeyedAttributeSet NonKeyedAttribute { get; }
    }

    public interface IConstituentDataPoint : IDataPoint, IEnumerable<KeyValuePair<IEntityDescriptor, object>>
    {
        object GetValue(IEntityDescriptor child);

        NonKeyedAttributeSet GetNonKey(IEntityDescriptor child);

        void Add(IEntityDescriptor child, object obj, NonKeyedAttributeSet nonKey);

        void AddWithNull(IEntityDescriptor child, object obj);

        IList<IEntityDescriptor> Entities { get; }
    }
}
