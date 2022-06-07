
using Compi.SpecificationPattern.Logic.DomainModel;
using Compi.SpecificationPattern.Logic.Infrastructure.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Linq.Expressions;

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
        public async Task<Project?> GetProjectWithProblemsById(int id)
        {
            var project = _projectRepository.GetProjectById(id);


            Func<Project, bool> hasProblems = Project.IsOnTime.Compile();

            Expression<Func<Project, bool>> expression = true ? Project.IsOnTime : x => true;

            if(!hasProblems(project))
            {
                project = null;
            }

            return await Task.FromResult(project);
        }



        [HttpGet]
        public async Task<List<Project>> GetProjectsWithProblems()
        {
            var projects = _projectRepository.GetProjectsWithProblems();

            return await Task.FromResult(projects);
        }



        
    }
}
