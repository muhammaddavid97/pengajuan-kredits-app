using Microsoft.EntityFrameworkCore;
using SkyWorkTask.Model.Context;
using SkyWorkTask.Repository;
using SkyWorkTask.Repository.Implementation;
using SkyWorkTask.Service.Implementation;
using SkyWorkTask.Service.Interface;

var builder = WebApplication.CreateBuilder(args);


// Add Configure Database PostgreSQL
builder.Services.AddDbContext<PengajuanKreditContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

// Register repositories and services implementation of Dependency Injection
builder.Services.AddScoped<IPengajuanKreditRepository, PengajuanKreditRepositoryImplementation>();
builder.Services.AddScoped<IPengajuanKreditService, PengajuanKreditServiceImplementation>();

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
