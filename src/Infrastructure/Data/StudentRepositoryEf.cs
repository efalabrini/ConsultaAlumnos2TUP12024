using ConsultaAlumnos.Domain.Entities;
using ConsultaAlumnos.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsultaAlumnos.Infrastructure.Data;

public class StudentRepositoryEf : IStudentRepository
{
    private readonly ApplicationContext _context;
    public StudentRepositoryEf(ApplicationContext context)
    {

        _context = context;

    }

    public Student Add(Student student)
    {
        _context.Students.Add(student);
        _context.SaveChanges();
        return student;
    }

    public void Delete(Student student)
    {
        _context.Remove(student);
        _context.SaveChanges();

    }

    public List<Student> GetAll()
    {
        return _context.Students.ToList();
    }

    public Student? GetById(int id)
    {
        return _context.Students
            .FirstOrDefault(x => x.Id == id);
    }

    public void Update(Student student)
    {
        _context.Update(student);
        _context.SaveChanges();

    }

    public void SaveChanges()
    {
        _context.SaveChanges();
    }
}
