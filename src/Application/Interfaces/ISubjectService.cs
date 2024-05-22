using ConsultaAlumnos.Application.Models;
using ConsultaAlumnos.Application.Models.Requests;
using ConsultaAlumnos.Domain.Entities;

namespace ConsultaAlumnos.Application.Interfaces
{
    public interface ISubjectService
    {
        Subject Create(SubjectCreateRequest subject);
        void Delete(int id);
        List<SubjectDto> GetAll();

        List<Subject> GetAllFullData();
        SubjectDto GetById(int id);
        void Update(int id, SubjectUpdateRequest subject);
    }
}