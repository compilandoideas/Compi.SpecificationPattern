using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Compi.SpecificationPattern.Logic.DomainModel
{
    public class Project
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTimeOffset StartDate { get; set; }
        public DateTimeOffset EndDate { get; set; }
        public Status Status { get; set; }


        public static readonly Expression<Func<Project, bool>> IsOnTime = 
            x => x.EndDate <= DateTimeOffset.UtcNow && (x.Status != Status.Complete);
        
    }

    public enum Status
    {
        Pending = 1,
        InProgress = 2,
        Complete = 3

    }
}
