using POC_Signal.Handler;
using POC_SignalR.Hubs;
using POC_SignalR.Model;
using System.Collections.Generic;
using System.Linq;

namespace POC_SignalR.Service
{
    public interface IEmployeeService
    {
        List<Employee> GetEmployees();
        void AddEmployee(Employee emp);
        void UpdateEmployee(Employee emp);
        void DeleteEmployee(int id);
    }

    public class EmployeeService : IEmployeeService
    {

        public List<Employee> GetEmployees()
        {
            var _employees = JsonDataHandler.GetEmployeesDefaultData();
            var _projects = JsonDataHandler.GetProjectsDefaultData();
            foreach(Employee employee in _employees)
            {
                List<Project> projects = _projects.Where(p => p.EmpId == employee.Id).ToList();
                if(projects != null && projects.Any())
                {
                    employee.Projects.AddRange(projects);
                }
            }

            return _employees;
        }

        public void AddEmployee(Employee emp)
        {
            var _employees = JsonDataHandler.GetEmployeesDefaultData();
            _employees.Add(emp);
            JsonDataHandler.SetEmployees(_employees);
            BroadCastEmployeeChangs();
        }

        public void UpdateEmployee(Employee emp)
        {
            var _employees = JsonDataHandler.GetEmployeesDefaultData();
            var e = _employees.First(em => em.Id == emp.Id);
            e.Name = emp.Name;
            e.Salary = emp.Salary;
            e.StartDate = emp.StartDate;
            e.TotalExp = emp.TotalExp;
            JsonDataHandler.SetEmployees(_employees);
            BroadCastEmployeeChangs();
        }

        public void DeleteEmployee(int id)
        {
            var _employees = JsonDataHandler.GetEmployeesDefaultData();
            var e = _employees.First(em => em.Id == id);
            _employees.Remove(e);
            JsonDataHandler.SetEmployees(_employees);
            BroadCastEmployeeChangs();
        }

        public void BroadCastEmployeeChangs()
        {
            HubServer.Current.Clients.All.SendCoreAsync("GetAllEmployee", new object[] { GetEmployees() });
        }
    }
}
