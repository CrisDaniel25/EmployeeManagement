using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;
using EmployeeManagement.Domain.Interfaces;
using EmployeeManagement.Infrastructure.Data;
using EmployeeManagement.Domain.Interfaces.Base;
using EmployeeManagement.Infrastructure.Repositories;
using EmployeeManagement.Infrastructure.Repositories.Base;

var builder = WebApplication.CreateBuilder(args);

/* Add services to the container. */

builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        // Ignore self reference loop
        options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
        // set as pascal case
        options.JsonSerializerOptions.PropertyNamingPolicy = null;
    });

/* Db Context and Database connection. */

builder.Services.AddDbContext<DataContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DBConnection"));
});

/* Mapped one object to other. */

builder.Services.AddAutoMapper(typeof(Program));

/* new instance is provided to every controller and every service. */

builder.Services.AddTransient<IEmployee, EmployeeRepository>();
builder.Services.AddTransient<IDepartment, DepartmentRepository>();
builder.Services.AddTransient<IPosition, PositionRepository>();
builder.Services.AddTransient<IUnitOfWork, UnitOfWork>();

var app = builder.Build();

/* Configure the HTTP request pipeline. */

/* global cors policy */
app.UseCors(builder =>
{
    builder.AllowAnyHeader();
    builder.AllowAnyMethod();
    builder.AllowAnyOrigin();
});

app.UseAuthorization();

app.MapControllers();

app.Run();
