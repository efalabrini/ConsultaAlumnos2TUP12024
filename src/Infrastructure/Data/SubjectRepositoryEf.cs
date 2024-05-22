using ConsultaAlumnos.Domain.Entities;
using ConsultaAlumnos.Domain.Exceptions;
using ConsultaAlumnos.Domain.Interfaces;
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
            return _context.Subjects.FirstOrDefault(x => x.Id == id);
        }

        public void Update(Subject subject)
        {
            _context.Subjects.Update(subject);
            _context.SaveChanges();
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
