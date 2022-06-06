using Compi.SpecificationPattern.Logic.DomainModel;
using System;
using System.Collections.Generic;
using System.Linq;
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


        public List<Project> GetProjectInRange()
        {

           var projects = _context
                .Projects
                .Where(x => x.StartDate > new DateTimeOffset(2022, 1, 1, 0, 0, 0, TimeSpan.Zero) && x.EndDate <=  DateTimeOffset.UtcNow.AddMonths(1))
                .ToList();

            return projects;

        }

    }
}
