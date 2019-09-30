using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoRepair
{
    public class Car
    {
        private List<Repair> repairs;

        public string Make { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }

        /// <summary>
        /// Simple constructor for creating a car object
        /// </summary>
        /// <param name="make"></param>
        /// <param name="model"></param>
        /// <param name="year"></param>
        public Car(string make, string model, int year)
        {
            this.Make = make;
            this.Model = model;
            this.Year = year;
            repairs = new List<Repair>();
        }


        /// <summary>
        /// Add a new repair to the car
        /// </summary>
        /// <param name="repairID">A unique string ID</param>
        /// <param name="repairDate">Date of the repair</param>
        /// <param name="description">Brief description of the repair</param>
        /// <param name="amount">Total amount paid for the repair</param>
        public void AddRepair(string repairID, DateTime repairDate, string description, double amount)
        {
            repairs.Add(new ListRepair(repairID, repairDate, description, amount));
        }

        public void AddRepair(Repair repair)
        {
            repairs.Add(repair);
        }
        /// <summary>
        /// How many reparis are made to the car
        /// </summary>
        /// <returns></returns>
        public int NumberRepairs()
        {
            return repairs.Count();
        }

        /// <summary>
        /// Overrides the ToString method to return a single line of the state of the Car object
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return Year + " " + Make + " " + Model;
        }

        /// <summary>
        /// Total amount of money spent on repairs for the car
        /// </summary>
        /// <returns></returns>
        public double totalRepairAmount()
        {
            double result = 0;
            foreach (Repair r in repairs)
            {
                result += r.Amount;
            }
            return result;
        }

        /// <summary>
        /// Return the latest repair made to the car
        /// </summary>
        /// <returns></returns>
        public Repair LatestRepair()
        {
            Repair result = (repairs.Count > 0) ? repairs[0] : null; //Add first repair or null to be returned
            foreach (Repair r in repairs)
            {
                if (r.RepairDate.CompareTo(result.RepairDate) > 0)
                    result = r;
            }
            return result;
        }

        /// <summary>
        /// Remove repair based on repair ID
        /// </summary>
        /// <param name="repairID"></param>
        public void RemoveRepair(string repairID)
        {
            Repair found = null;
            foreach (Repair r in repairs)
            {
                if (r.RepairID.Equals(repairID))
                {
                    found = r;
                    break; //get out of the loop
                }
            } //end loop
            repairs.Remove(found);
        }

        /// <summary>
        /// Remove all repairs made on a particular date
        /// </summary>
        /// <param name="removeDate">Date used as the search parameter</param>
        public void RemoveRepair(DateTime removeDate)
        {
            List<Repair> results = new List<Repair>();
            foreach (Repair r in repairs)
            {
                if (r.RepairDate.Equals(removeDate))
                    results.Add(r);
            }
            repairs = repairs.Except(results).ToList<Repair>();
        }

        public List<string> sortedRepairs()
        {
            repairs.Sort();
            List<string> result = new List<string>();
            foreach (Repair r in repairs)
            {
                string s = string.Format("{0:C} - {1}", r.Amount, r.RepairDate.ToShortDateString());
                result.Add(s);
            }
            return result;
        }
    }
}
