using ConsultaAlumnos.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class ApplicationContext :DbContext
    {
        public DbSet<Subject> Subjects {get; set;}
    }
}