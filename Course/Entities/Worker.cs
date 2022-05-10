using Course.Entities.Enums;
using System.Collections.Generic;

namespace Course.Entities
{
    class Worker
    {
        public string Name { get; set; }
        public WorkerLevel level { get; set; }
        public double BaseSalary { get; set; }
        public Department Department { get; set; }

        List<HourContract> Contracts = new List<HourContract>();
        public Worker(string name, WorkerLevel level, double baseSalary, Department depart)
        {
            Name = name;
            this.level = level;
            BaseSalary = baseSalary;
            Department = depart;
        }

        public void AddContract(HourContract contract)
        {
            Contracts.Add(contract);
        }

        public void RemoveContract(HourContract contract)
        {
            Contracts.Remove(contract);
        }

        public double Income(int year, int month)
        {
            double sun = BaseSalary;
            foreach(HourContract contract in Contracts)
            {
                if(contract.Data.Year == year && contract.Data.Month == month)
                {
                    sun += contract.TotalValue();
                }
            }
            return sun;
        }

    }
}
