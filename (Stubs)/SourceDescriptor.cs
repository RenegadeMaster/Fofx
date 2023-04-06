using System;

namespace Fofx
{
    [Serializable]
    public class SourceDescriptor : IComparable
    {
        public int SourceID { get; }

        public Preference CodePreference { get; set; }

        public int CompareTo(object obj)
        {
            throw new NotImplementedException();
        }
    }
}