using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TenthLab
{
    internal class SortByPrice : IComparer
    {
        public int Compare(object x, object y)
        {
            Commodity c1 = (Commodity)x;
            Commodity c2 = (Commodity)y;
            if (c1.Rub < c2.Rub)  return -1;
            if (c1.Rub == c2.Rub) { if (c1.Kop < c2.Kop) return -1; else if (c1.Kop == c2.Kop) return 0; }
            return 1;
        }
    }
}
