using Compi.SpecificationPattern.Logic.DomainModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Compi.SpecificationPattern.Logic.Infrastructure.Repositories
{
    public class ProjectRepository
    {

        private readonly AppDbContext _context;



        public ProjectRepository(AppDbContext context)
        {
            _context = context?? 
                throw new ArgumentNullException(nameof(context));

        }



        public Project AddProject(Project project)
        {

            _context.Projects.Add(project); 
            _context.SaveChanges();

            return project;
        }



        public Project GetProjectById(int id)
        {

            var project = _context.Projects.FirstOrDefault(x=> x.Id == id);
         
            return project;
        }


        public List<Project> GetProjectsWithProblems()
        {

           var projects = _context
                .Projects
                .Where( x => x.EndDate <=  DateTimeOffset.UtcNow.AddMonths(1) || x.Status == Status.Pending)
                .ToList();

            return projects;

        }


        public List<Project> SearchProjects(Expression<Func<Project, bool>> predicate)
        {
            var projects = _context.Projects.Where(predicate).ToList();

            return projects;
        }


        public IReadOnlyList<Project> SearchProjects(GenericSpecification<Project> specification)
        {
            var projects = _context.Projects.Where(specification.Expression).ToList();

            return projects;
        }

        public IReadOnlyList<Project> GetProjectsDelayed(Specification<Project> specification)
        {
            var projects = _context
                .Projects
                .Where(specification.ToExpression())
                .Include(x => x.People)
                .ToList();

            return projects;
        }

    }
}
