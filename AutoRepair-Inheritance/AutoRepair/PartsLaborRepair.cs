using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoRepair
{
    public class PartsLaborRepair : Repair
    {
        private int minutes;
        private const double hourlyRate = 75.0;
        private List<Part> parts;

        public int Minutes { get { return minutes; } }

        public override double Amount
        {
            get
            {
                double result = 0;
                result += (float)(Minutes / 60 * hourlyRate);
                foreach (Part p in parts)
                {
                    result += p.Amount;
                }
                return result;
            }
        }

        public PartsLaborRepair(string repairID, DateTime repairDate)
            : base(repairID, repairDate)
        {
            minutes = 0;
            parts = new List<Part>();
        }

        public void AddPart(Part part)
        {
            parts.Add(part);
        }

        public void AddMinutes(int minutes)
        {
            if (minutes > 0)
                this.minutes += minutes;
        }

        public void AddHours(double hours)
        {
            if (hours > 0)
                this.minutes += (int)Math.Round(hours * 60);
        }
    }
}
