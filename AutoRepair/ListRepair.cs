using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoRepair
{
    public class ListRepair : Repair
    {
        private double amount;
        public string Description { get; set; }
        public override double Amount
        {
            get { return amount; }
        }
        public ListRepair(string repairID, DateTime repairDate, string description, double amount)
            : base(repairID, repairDate)
        {

            this.Description = description;
            this.amount = amount;
        }
    }
}
