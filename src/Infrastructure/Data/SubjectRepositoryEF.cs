using ConsultaAlumnos.Domain.Entities;
using ConsultaAlumnos.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsultaAlumnos.Infrastructure.Data
{
    public class SubjectRepositoryEF : ISubjectRepository
    {

        public Subject Add(Subject subject)
        {
            subject.Name += " Guardado en EF";
            return subject;
        }

        public void Delete(Subject subject)
        {
            throw new NotImplementedException();
        }

        public List<Subject> GetAll()
        {
            throw new NotImplementedException();
        }

        public Subject GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Subject subject)
        {
            throw new NotImplementedException();
        }
    }
}
