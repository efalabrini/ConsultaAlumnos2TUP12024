using ConsultaAlumnos.Application.Interfaces;
using ConsultaAlumnos.Application.Services;
using ConsultaAlumnos.Domain.Interfaces;
using ConsultaAlumnos.Infrastructure.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

#region Services
builder.Services.AddScoped<ISubjectService, SubjectService>();
#endregion

#region Repositories
builder.Services.AddScoped<ISubjectRepository, SubjectRepository>();
#endregion

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
