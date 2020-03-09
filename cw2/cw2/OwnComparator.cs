using System;
using System.Collections.Generic;
using System.Text;

namespace cw2
{
    class OwnComparator : IEqualityComparer<student>
    {
        public bool Equals(student x, student y)
        {
            return StringComparer.InvariantCultureIgnoreCase.Equals($"{x.fname} {x.lname} {x.indexNumber}", $"{y.fname} {y.lname} {y.indexNumber}");
        }

        public int GetHashCode(student obj)
        {
            return StringComparer.CurrentCultureIgnoreCase.GetHashCode($"{obj.fname} {obj.lname} {obj.indexNumber}");
        }
    }
}