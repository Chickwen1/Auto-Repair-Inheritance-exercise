using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoRepair
{
    public class DateComparer : IComparer<Repair>
    {
         public int Compare(Repair x, Repair y)
         {
                return x.RepairDate.CompareTo(y.RepairDate);
         }
        
    }
}
