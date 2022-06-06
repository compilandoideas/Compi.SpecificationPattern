using Compi.SpecificationPattern.Logic.DomainModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Compi.SpecificationPattern.Logic.Infrastructure
{
    public class AppDbContext : DbContext
    {

        private readonly string _connectionString;

        public DbSet<Project> Projects { get; set; }

        //public AppDbContext(string connectionString)
        //{
        //    connectionString = connectionString ??
        //        throw new ArgumentNullException(nameof(connectionString));
        //}


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            base.OnModelCreating(modelBuilder);
        }


        public AppDbContext(DbContextOptions<AppDbContext> options)
          : base(options)
        {
        }



        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {



            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder
                    .UseSqlServer(_connectionString)
                    ;
            }


        }




    }
}
