using Newtonsoft.Json;
using POC_SignalR.Model;
using System;
using System.Collections.Generic;
using System.IO;

namespace POC_Signal.Handler
{
    public static class JsonDataHandler
    {
        public static List<Employee> GetEmployeesDefaultData()
        {
            List<Employee> employees = null;
            string str = File.ReadAllText(Environment.CurrentDirectory + "\\DefaultData\\Employee.json");
            if (string.IsNullOrEmpty(str))
            {
                employees = new List<Employee>();
            }
            else
            {
                employees = (List<Employee>)JsonConvert.DeserializeObject(str, typeof(List<Employee>));
            }

            return employees;
        }

        public static List<Project> GetProjectsDefaultData()
        {
            List<Project> projects = null;
            string str = File.ReadAllText(Environment.CurrentDirectory + "\\DefaultData\\Project.json");
            if (string.IsNullOrEmpty(str))
            {
                projects = new List<Project>();
            }
            else
            {
                projects = (List<Project>)JsonConvert.DeserializeObject(str, typeof(List<Project>));
            }

            return projects;
        }

        public static void SetEmployees(List<Employee> employees)
        {
            string state = JsonConvert.SerializeObject(employees);
            File.WriteAllText(Environment.CurrentDirectory + "\\DefaultData\\Employee.json", state);
        }

        public static void SetProjects(List<Project> projects)
        {
            string state = JsonConvert.SerializeObject(projects);
            File.WriteAllText(Environment.CurrentDirectory + "\\DefaultData\\Project.json", state);
        }
    }
}
