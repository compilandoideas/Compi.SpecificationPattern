using Compi.SpecificationPattern.Logic.Domain.Specifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Compi.SpecificationPattern.Logic.Domain
{
    public sealed class ProjectsDelayed : Specification<Project>
    {
        private readonly DateTimeOffset _today;

        public ProjectsDelayed(DateTimeOffset today)
        {
            _today = today;
        }

        public override Expression<Func<Project, bool>> ToExpression()
        {
            return project => project.EndDate < _today;
        }
    }


    public sealed class ProjectWithoutPeople : Specification<Project>
    {
        public override Expression<Func<Project, bool>> ToExpression()
        {
            return project => project.People.Count == 0;
        }
    }
}
