using ConsultaAlumnos.Domain.Entities;

namespace ConsultaAlumnos.Domain.Interfaces;

public interface IStudentRepository
{
    Student Add(Student student);
    void Delete(Student student);
    List<Student> GetAll();
    Student? GetById(int id);
    void SaveChanges();
    void Update(Student student);
}