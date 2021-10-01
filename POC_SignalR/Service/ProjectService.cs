using POC_Signal.Handler;
using POC_SignalR.Hubs;
using POC_SignalR.Model;
using System.Collections.Generic;
using System.Linq;

namespace POC_SignalR.Service
{
    public interface IProjectService
    {
        List<Project> GetProjects();
        List<Project> GetProjectsByEmpId(int empId);
        void AddProject(Project prj);
        void UpdateProject(Project prj);
        void DeleteProject(int id);
        void AddMultipleProjects(List<Project> prjs);
        void UpdateMultipleProjects(List<Project> prjs);
        void DeleteMultipleProjects(int[] ids);
    }

    public class ProjectService : IProjectService
    {
        public ProjectService()
        {
            BroadCastProjectGetAllChangs();
        }

        public List<Project> GetProjects()
        {
            return JsonDataHandler.GetProjectsDefaultData();
        }

        public List<Project> GetProjectsByEmpId(int empId)
        {
            var _projects = JsonDataHandler.GetProjectsDefaultData();
            return _projects.Where(p => p.EmpId == empId).ToList();
        }

        public void AddProject(Project prj)
        {
            var _projects = JsonDataHandler.GetProjectsDefaultData();
            _projects.Add(prj);
            JsonDataHandler.SetProjects(_projects);
            HubServer.Current.Clients.All.SendCoreAsync("AddProject", new object[] { prj });
        }

        public void UpdateProject(Project prj)
        {
            var _projects = JsonDataHandler.GetProjectsDefaultData();
            var e = _projects.First(pr => pr.Id == prj.Id);
            e.EmpId = prj.EmpId;
            e.Name = prj.Name;
            e.StartedDate = prj.StartedDate;
            e.FinishedDate = prj.FinishedDate;
            JsonDataHandler.SetProjects(_projects);
            HubServer.Current.Clients.All.SendCoreAsync("UpdateProject", new object[] { prj });
        }

        public void DeleteProject(int id)
        {
            var _projects = JsonDataHandler.GetProjectsDefaultData();
            var e = _projects.First(em => em.Id == id);
            _projects.Remove(e);
            JsonDataHandler.SetProjects(_projects);
            HubServer.Current.Clients.All.SendCoreAsync("DeleteProject", new object[] { id });
        }

        public void AddMultipleProjects(List<Project> prjs)
        {
            var _projects = JsonDataHandler.GetProjectsDefaultData();
            _projects.AddRange(prjs);
            JsonDataHandler.SetProjects(_projects);
            HubServer.Current.Clients.All.SendCoreAsync("AddMultipleProject", new object[] { prjs });
        }

        public void UpdateMultipleProjects(List<Project> prjs)
        {
            var _projects = JsonDataHandler.GetProjectsDefaultData();
            foreach (Project prj in prjs)
            {
                var e = _projects.First(pr => pr.Id == prj.Id);
                e.EmpId = prj.EmpId;
                e.Name = prj.Name;
                e.StartedDate = prj.StartedDate;
                e.FinishedDate = prj.FinishedDate;                
            }

            JsonDataHandler.SetProjects(_projects);
            HubServer.Current.Clients.All.SendCoreAsync("UpdateMultipleProject", new object[] { prjs });
        }

        public void DeleteMultipleProjects(int[] ids)
        {
            var _projects = JsonDataHandler.GetProjectsDefaultData();
            foreach (int id in ids)
            {
                var e = _projects.First(em => em.Id == id);
                _projects.Remove(e);
            }

            JsonDataHandler.SetProjects(_projects);
            HubServer.Current.Clients.All.SendCoreAsync("DeleteMultipleProject", new object[] { ids });
        }
        public void BroadCastProjectGetAllChangs()
        {
            HubServer.Current.Clients.All.SendCoreAsync("GetAllProjects", new object[] { JsonDataHandler.GetProjectsDefaultData() });
        }
    }
}
