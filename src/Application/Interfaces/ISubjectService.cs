using ConsultaAlumnos.Application.Models.Requests;
using ConsultaAlumnos.Domain.Entities;

namespace ConsultaAlumnos.Application.Interfaces
{
    public interface ISubjectService
    {
        Subject Create(SubjectCreateRequest subject);
        void Delete(int id);
        List<Subject> GetAll();
        Subject GetById(int id);
        void Update(int id, SubjectUpdateRequest subject);
    }
}