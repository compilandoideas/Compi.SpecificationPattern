
using Compi.SpecificationPattern.Logic.Domain;
using Compi.SpecificationPattern.Logic.DomainModel;
using Compi.SpecificationPattern.Logic.Infrastructure.Repositories;
using Compi.SpecificationPattern.Logic.Utils;
using Microsoft.AspNetCore.Mvc;
using System.Linq.Expressions;

namespace Compi.SpecificationPattern.Api.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
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

            //programador que quiere ver precio hora o valor proyecto
            var project = _projectRepository.GetProjectById(id);

            //1
            Func<Project, bool> hasProblems = Project.IsOnTime.Compile();
            
            //2
            Expression<Func<Project, bool>> expression = true ? Project.IsOnTime : x => true;

           //Para Validar.
            if(!hasProblems(project))
            {
                project = null;
            }

            return await Task.FromResult(project);
        }



        [HttpGet]
        public async Task<List<Project>> SearchProjects()
        {
            var specification = new GenericSpecification<Project>(x => x.StartDate > DateTimeOffset.UtcNow);

            var projects = _projectRepository.SearchProjects(specification.Expression);

            //var projects = _projectRepository.GetProjectsWithProblems();

            return await Task.FromResult(projects);
        }


        [HttpGet]
        public async Task<List<Project>> GetProjectsDelayed()
        {
            var specProjectDelayed = new ProjectsDelayed(DateTimeOffset.UtcNow);
            var specProjectWithoutPeople = new ProjectWithoutPeople();

            Specification<Project> spec = specProjectDelayed.And(specProjectWithoutPeople);

            var projects = _projectRepository.GetProjectsDelayed(spec);
            

            return await Task.FromResult(projects.ToList());
        }



    }
}
