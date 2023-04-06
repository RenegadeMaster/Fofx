using System;
using System.Collections.Generic;

namespace Fofx
{
    [Serializable]
    public class EntityDescriptor : IEntityDescriptor
    {
        public EntityDescriptor(int id) { }

        public int ID => throw new NotImplementedException();

        public string Code => throw new NotImplementedException();

        public int CodeTypeID => throw new NotImplementedException();

        public string CodeType => throw new NotImplementedException();

        public string FullCode => throw new NotImplementedException();

        public string Value => throw new NotImplementedException();

        public bool IsVirtual => throw new NotImplementedException();

        public bool IsDefault => throw new NotImplementedException();

        public IDictionary<string, string> Properties => throw new NotImplementedException();

        public IEntityDescriptor Clone()
        {
            throw new NotImplementedException();
        }

        public int CompareTo(IEntityDescriptor other)
        {
            throw new NotImplementedException();
        }

        public int CompareTo(object obj)
        {
            throw new NotImplementedException();
        }

        public IEntityDescriptor CreateAlias(string alias)
        {
            throw new NotImplementedException();
        }
    }
}