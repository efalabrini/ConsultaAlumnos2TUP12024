using ConsultaAlummos2TUP12024.Domain.Entities;

namespace ConsultaAlummos2TUP12024.Domain.Interfaces;

public interface ISubjectRepository
{
    Subject GetById(int id);

    Subject Add(Subject subject);

    void Update (Subject subject);

    void Delete (Subject subject);
}