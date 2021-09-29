using POC_Signal.Handler;
using POC_SignalR.Model;
using System;
using System.Collections.Generic;

namespace POC_SignalR.Service
{
    public class LoadDefaultDataService
    {
        public LoadDefaultDataService()
        {
            List<Employee> employees = JsonDataHandler.GetEmployeesDefaultData();
            if (employees.Count == 0)
            {
                employees = new List<Employee>()
                {
                    new Employee(){ Id = 1, Name = "Deepak", Salary = 10000, StartDate = DateTime.Now.AddMonths(-3), TotalExp = 10 },
                    new Employee(){ Id = 2, Name = "Sanjay", Salary = 273630, StartDate = DateTime.Now.AddMonths(-4), TotalExp = 2 },
                    new Employee(){ Id = 3, Name = "Ravi", Salary = 14500, StartDate = DateTime.Now.AddMonths(-1), TotalExp = 4 },
                    new Employee(){ Id = 4, Name = "Ajay", Salary = 10600, StartDate = DateTime.Now.AddMonths(-19), TotalExp = 6 },
                    new Employee(){ Id = 5, Name = "Jatin", Salary = 109373, StartDate = DateTime.Now.AddMonths(-2), TotalExp = 19 },
                };
                JsonDataHandler.SetEmployees(employees);
            }

            List<Project> projects = JsonDataHandler.GetProjectsDefaultData();
            if (projects.Count == 0)
            {
                projects = new List<Project>()
                {
                    new Project(){ Id = 1, EmpId = 1, Name = "Wenco", StartedDate = DateTime.Now.AddYears(-1), FinishedDate = null },
                    new Project(){ Id = 2, EmpId = 1, Name = "Yamaha", StartedDate = DateTime.Now.AddYears(-2), FinishedDate = DateTime.Now.AddYears(-1) },
                    new Project(){ Id = 3, EmpId = 1, Name = "ProData", StartedDate = DateTime.Now.AddYears(-3), FinishedDate = DateTime.Now.AddYears(-2) },
                    new Project(){ Id = 4, EmpId = 3, Name = "Cactus", StartedDate = DateTime.Now.AddMonths(-5), FinishedDate = DateTime.Now.AddMonths(-3) },
                    new Project(){ Id = 5, EmpId = 3, Name = "GTO", StartedDate = DateTime.Now.AddMonths(-10), FinishedDate = DateTime.Now.AddMonths(-8) },
                    new Project(){ Id = 6, EmpId = 4, Name = "FIM", StartedDate = DateTime.Now.AddMonths(-12), FinishedDate = DateTime.Now.AddMonths(-1) },
                    new Project(){ Id = 7, EmpId = 4, Name = "QuickZip", StartedDate = DateTime.Now.AddYears(-3), FinishedDate =null },
                };
                JsonDataHandler.SetProjects(projects);
            }


        }
    }
}
