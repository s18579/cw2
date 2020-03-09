using System;
using System.Collections.Generic;
using System.Text;

namespace cw2
{
    class OwnComparator : IEqualityComparer<Student>
    {
        public bool Equals(Student x, Student y)
        {
            return StringComparer.InvariantCultureIgnoreCase.Equals($"{x.Imie} {x.Nazwisko} {x.Index}", $"{y.Imie} {y.Nazwisko} {y.Index}");
        }

        public int GetHashCode(Student obj)
        {
            return StringComparer.CurrentCultureIgnoreCase.GetHashCode($"{obj.Imie} {obj.Nazwisko} {obj.Index}");
        }
    }
}
