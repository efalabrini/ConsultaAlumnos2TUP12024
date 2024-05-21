using ConsultaAlumnos.Domain.Entities;
using ConsultaAlumnos.Domain.Exceptions;
using ConsultaAlumnos.Domain.Interfaces;
using System.Security.Cryptography.X509Certificates;

namespace ConsultaAlumnos.Infrastructure.Data;

public class SubjectRepository : ISubjectRepository
{
    static int LastIdAssigned = 0;
    static List<Subject> subjects = [];
    public Subject Add(Subject subject)
    {
        subject.Id = ++LastIdAssigned;
        subjects.Add(subject);
        return subject;
    }

    public void Delete(Subject subject)
    {
        subjects.Remove(subject);
    }

    public List<Subject> GetAll()
    {
        return subjects.ToList();
    }

    public Subject GetById(int id)
    {
        return subjects.FirstOrDefault(x => x.Id == id)
            ?? throw new NotFoundException(nameof(Subject),id);
    }

    public void Update(Subject subject)
    {
        var obj = subjects.FirstOrDefault(x => x.Id == subject.Id)
            ?? throw new NotFoundException(nameof(Subject), subject.Id);

        obj.Name = subject.Name;

    }

    public bool AlreadyCreated(string name)
    {
        var obj = subjects.Find(x => x.Name == name);
        if (obj != null)
        {
            return true;
        }else
        {
            return false;
        }
    }
}
