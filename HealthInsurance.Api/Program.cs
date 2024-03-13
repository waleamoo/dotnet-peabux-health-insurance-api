using HealthInsurance.DataAccess.Models;
using HealthInsurance.DataAccess.Repository;
using HealthInsurance.Service.Helpers;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<HealthInsuranceContext>(o => o.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Add AutoMapperProfile 
builder.Services.AddAutoMapper(typeof(AutoMapperProfiles).Assembly);

// inject all the services 
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

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
