using ConsultaAlumnos.Domain.Entities;
using ConsultaAlumnos.Domain.Exceptions;
using ConsultaAlumnos.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsultaAlumnos.Infrastructure.Data
{
    public class SubjectRepositoryEf : ISubjectRepository
    {
        private readonly ApplicationContext _context;
        public SubjectRepositoryEf(ApplicationContext context)
        {

            _context = context;

        }

        public Subject Add(Subject subject)
        {
            _context.Subjects.Add(subject);
            _context.SaveChanges();
            return subject;
        }

        public void Delete(Subject subject)
        {
            _context.Remove(subject);
            _context.SaveChanges();

        }

        public List<Subject> GetAll()
        {
            return _context.Subjects.ToList();
        }

        public Subject? GetById(int id)
        {
            return _context.Subjects
                //.AsNoTracking() //Tema avanzado. Pueden ignorar esta linea.
                .FirstOrDefault(x => x.Id == id);
        }

        public void Update(Subject subject)
        {
            //Tema avanzado. Pueden ignorar estas lineas.
            /*
            var entry = _context.Entry(subject); 
            if (entry.State == EntityState.Detached) _context.Subjects.Update(subject);
            */

            _context.SaveChanges();

        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
