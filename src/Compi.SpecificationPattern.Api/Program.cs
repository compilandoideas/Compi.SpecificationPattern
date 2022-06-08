using Compi.SpecificationPattern.Logic.Infrastructure;
using Compi.SpecificationPattern.Logic.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddTransient<ProjectRepository>();



string connectionString = builder.Configuration["ConnectionString"].ToString();

builder.Services.AddDbContext<AppDbContext>(
    options =>
    {
        options.UseSqlServer(connectionString);
        options.EnableDetailedErrors();
        options.EnableSensitiveDataLogging();

    }
);



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
