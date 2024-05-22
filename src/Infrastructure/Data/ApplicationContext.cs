using ConsultaAlumnos.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class ApplicationContext :DbContext
    {
        private readonly bool isTestingEnvironment;
        public DbSet<Subject> Subjects {get; set;}

        //llamamos al constructor de DbContext que es que acepta las opciones
        public ApplicationContext(DbContextOptions<ApplicationContext> options, bool isTestingEnvironment = false) : base(options)
        {
            this.isTestingEnvironment = isTestingEnvironment;
        }
   
    }
}