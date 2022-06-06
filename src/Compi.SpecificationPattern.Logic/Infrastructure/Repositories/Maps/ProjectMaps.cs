using Compi.SpecificationPattern.Logic.DomainModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compi.SpecificationPattern.Logic.Infrastructure.Repositories.Maps
{
    public class ProjectMaps : IEntityTypeConfiguration<Project>
    {
        public void Configure(EntityTypeBuilder<Project> builder)
        {
            builder.ToTable("Projects");

            builder.Property(x => x.Id)
                .ValueGeneratedOnAdd();

            builder
              .Property(x => x.Name)
              .HasMaxLength(200);


            //builder
            //  .Property(x => x.StartDate)
            //  .HasMaxLength(200);


        }
    }
}
