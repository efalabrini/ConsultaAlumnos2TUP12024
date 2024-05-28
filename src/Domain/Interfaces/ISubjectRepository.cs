using ConsultaAlumnos.Domain.Entities;

namespace ConsultaAlumnos.Domain.Interfaces;

public interface ISubjectRepository
{
    Subject? GetById(int id);

    List<Subject> GetAll();
    Subject Add(Subject subject);

    void Update(Subject subject);

    void Delete(Subject subject);

    void SaveChanges();
}