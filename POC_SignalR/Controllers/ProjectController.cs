using Microsoft.AspNetCore.Mvc;
using POC_SignalR.Model;
using POC_SignalR.Service;
using System.Collections.Generic;

namespace POC_SignalR.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProjectController : ControllerBase
    {
        private readonly IProjectService _projectService;

        public ProjectController(IProjectService projectService)
        {
            _projectService = projectService;
        }

        [HttpPost]
        [Route("add")]
        public void AddProject([FromBody] Project project)
        {
            _projectService.AddProject(project);
        }

        [HttpPost]
        [Route("update")]
        public void UpdateProject([FromBody] Project project)
        {
            _projectService.UpdateProject(project);
        }

        [HttpPost]
        [Route("delete/{id}")]
        public void DeleteProject([FromRoute] int id)
        {
            _projectService.DeleteProject(id);
        }

        [HttpPost]
        [Route("multiple/add")]
        public void AddMulitpleProjects([FromBody] List<Project> projects)
        {
            _projectService.AddMultipleProjects(projects);
        }

        [HttpPost]
        [Route("multiple/update")]
        public void UpdateMultipleProjects([FromBody] List<Project> projects)
        {
            _projectService.UpdateMultipleProjects(projects);
        }

        [HttpPost]
        [Route("delete/multiple}")]
        public void DeleteProject([FromBody] int[] ids)
        {
            _projectService.DeleteMultipleProjects(ids);
        }

        [HttpGet]
        [Route("get")]
        public List<Project> GetProject()
        {
            return _projectService.GetProjects();
        }

        [HttpGet]
        [Route("get/{empId}")]
        public List<Project> GetProject([FromRoute] int empId)
        {
            return _projectService.GetProjectsByEmpId(empId);
        }
    }
}
