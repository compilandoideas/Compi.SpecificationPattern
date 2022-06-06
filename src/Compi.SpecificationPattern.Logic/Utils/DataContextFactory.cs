using Compi.SpecificationPattern.Logic.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compi.SpecificationPattern.Logic.Utils
{
    public class DataContextFactory : IDesignTimeDbContextFactory<AppDbContext>
    {
        public AppDbContext CreateDbContext(string[] args)
        {

            //TODO: Leer desde el archivo de configuración

            //var configuration = new ConfigurationBuilder()
            //     .SetBasePath(Directory.GetCurrentDirectory())
            //     .AddJsonFile("appsettings.json")
            //     .Build();


            // IConfiguration config = new ConfigurationBuilder()
            //.SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../EfDesignDemo.Web"))
            //.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            //.AddJsonFile($"appsettings.{Environment}.json", optional: true)
            //.AddEnvironmentVariables()
            //.Build();

            var dbContextBuilder = new DbContextOptionsBuilder<AppDbContext>();


            string connectionString = "Data Source=(localdb)\\mssqllocaldb;Initial Catalog=SpecificationPattern;Connect Timeout=30;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

            dbContextBuilder.UseSqlServer(
                connectionString,
                x => x.MigrationsAssembly("Compi.SpecificationPattern.Logic")
            );


            return new AppDbContext(dbContextBuilder.Options);

        }


    }
}
