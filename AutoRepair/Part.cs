using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoRepair
{
    public class Part
    {
        public string Description { get; set; }
        public double Amount { get; set; }

        public Part(string description, double amount)
        {
            this.Description = description;
            this.Amount = amount;
        }
    }
}
