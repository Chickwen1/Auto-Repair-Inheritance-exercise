using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoRepair
{
    public abstract class Repair
    {
        private string repairID;
        public abstract double Amount { get; }
        public DateTime RepairDate { get; set; }

        public string RepairID { get { return repairID; } }

        public Repair(string repairID, DateTime repairDate)
        {
            this.repairID = repairID;
            this.RepairDate = repairDate;
        }


    }
}
