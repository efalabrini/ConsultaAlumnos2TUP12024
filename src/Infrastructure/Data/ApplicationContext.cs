using ConsultaAlumnos.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsultaAlumnos.Infrastructure.Data;

public class ApplicationContext : DbContext
{
    public DbSet<Subject> Subjects { get; set; }

    public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
    {

    }

}



