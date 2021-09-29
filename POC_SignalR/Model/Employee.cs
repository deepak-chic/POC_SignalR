using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace POC_SignalR.Model
{
    public class Employee
    {
        public Employee()
        {
            Projects = new List<Project>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public double TotalExp { get; set; }
        public double Salary { get; set; }
        public DateTime StartDate { get; set; }
        public List<Project> Projects { get; set; }
    }
}
