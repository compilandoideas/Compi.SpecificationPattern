
using Compi.SpecificationPattern.Logic.DomainModel;
using Compi.SpecificationPattern.Logic.Infrastructure.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Compi.SpecificationPattern.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProjectController : Controller
    {

        private readonly ProjectRepository _projectRepository;

        public ProjectController(ProjectRepository projectRepository)
        {
            _projectRepository = projectRepository ?? 
                throw new ArgumentNullException(nameof(projectRepository));
        }


        [HttpPost]
        public async Task<IActionResult> AddProject(Project project)
        {

            var newProject = _projectRepository.AddProject(project);

            

            return await Task.FromResult(Ok(newProject));

        }


        [HttpGet]
        public async Task<List<Project>> GetProjectInRange()
        {
            var projects = _projectRepository.GetProjectInRange();

            return await Task.FromResult(projects);
        }



        
    }
}
