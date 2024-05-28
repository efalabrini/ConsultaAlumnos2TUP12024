using ConsultaAlumnos.Application.Models;
using ConsultaAlumnos.Application.Models.Requests;
using ConsultaAlumnos.Domain.Entities;

namespace ConsultaAlumnos.Application.Interfaces
{
    public interface IStudentService
    {
        Student Create(StudentCreateRequest studentCreateRequest);
        void Delete(int id);
        List<StudentDto> GetAll();
        List<Student> GetAllFullData();
        StudentDto GetById(int id);
        void Update(int id, StudentUpdateRequest studentUpdateRequest);
    }
}