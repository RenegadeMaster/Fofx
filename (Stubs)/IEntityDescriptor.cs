using System;
using System.Collections.Generic;

namespace Fofx
{
    public interface IEntityDescriptor : IComparable<IEntityDescriptor>, IComparable
    {
        int ID { get; }

        string Code { get; }

        int CodeTypeID { get; }

        string CodeType { get; }

        string FullCode { get; }

        string Value { get; }

        bool IsVirtual { get; }

        bool IsDefault { get; }

        IDictionary<string, string> Properties { get; }

        IEntityDescriptor CreateAlias(string alias);

        IEntityDescriptor Clone();
    }
}
