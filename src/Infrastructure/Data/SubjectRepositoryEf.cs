using ConsultaAlumnos.Domain.Entities;
using ConsultaAlumnos.Domain.Exceptions;
using ConsultaAlumnos.Domain.Interfaces;
using Infrastructure.Data;
using System.Security.Cryptography.X509Certificates;

namespace ConsultaAlumnos.Infrastructure.Data;

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
        _context.Subjects.Remove(subject);
        _context.SaveChanges();
    }

    public List<Subject> GetAll()
    {
        return _context.Subjects.ToList();
    }

    public Subject GetById(int id)
    {
        return _context.Subjects.FirstOrDefault(x => x.Id == id)
            ?? throw new NotFoundException(nameof(Subject), id);
    }

    public void Update(Subject subject)
    {
        //searchs the Subject in the DB by Id.
        var existingSubject = _context.Subjects.Find(subject.Id);

        //Validates if it exists.
        if (existingSubject == null)
        {
            //if not exists, throws an exception.
            throw new NotFoundException(nameof(Subject), subject.Id);
        }

        //if exists, updates it and save the changes in the DB.
        existingSubject.Name = subject.Name;
        _context.SaveChanges();
    }

}
    

