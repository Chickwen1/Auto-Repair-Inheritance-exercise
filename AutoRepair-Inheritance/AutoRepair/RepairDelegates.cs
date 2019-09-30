using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoRepair
{
    public static class RepairDelegates
    {
        public static int DateCompare(Repair r1, Repair r2)
        {
            return r1.RepairDate.CompareTo(r2.RepairDate);
        }

        public static int IDCompare(Repair r1, Repair r2)
        {
            return r1.RepairID.CompareTo(r2.RepairID);
        }

        public static bool BigRepairs(Repair target)
        {
            return (target.Amount > 500);
        }
    }
}
