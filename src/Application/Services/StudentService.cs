using ConsultaAlumnos.Application.Models.Requests;
using ConsultaAlumnos.Application.Models;
using ConsultaAlumnos.Domain.Entities;
using ConsultaAlumnos.Domain.Exceptions;
using ConsultaAlumnos.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsultaAlumnos.Application.Interfaces;

namespace ConsultaAlumnos.Application.Services;

public class StudentService : IStudentService
{
    private readonly IStudentRepository _studentRepository;
    public StudentService(IStudentRepository studentRepository)
    {
        _studentRepository = studentRepository;
    }

    public List<StudentDto> GetAll()
    {
        var list = _studentRepository.GetAll();

        return StudentDto.CreateList(list);
    }

    public List<Student> GetAllFullData()
    {
        return _studentRepository.GetAll();
    }

    public StudentDto GetById(int id)
    {
        var obj = _studentRepository.GetById(id)
            ?? throw new NotFoundException(nameof(Student), id);

        var dto = StudentDto.Create(obj);

        return dto;
    }

    public Student Create(StudentCreateRequest studentCreateRequest)
    {
        var obj = new Student();
        obj.Name = studentCreateRequest.Name;
        obj.LastName = studentCreateRequest.LastName;
        obj.Password = studentCreateRequest.Password;
        obj.Email = studentCreateRequest.Email;
        obj.UserName = studentCreateRequest.UserName;
        return _studentRepository.Add(obj);
    }

    public void Update(int id, StudentUpdateRequest studentUpdateRequest)
    {

        var obj = _studentRepository.GetById(id);

        if (obj == null)
            throw new NotFoundException(nameof(Subject), id);

        if (studentUpdateRequest.Name != string.Empty) obj.Name = studentUpdateRequest.Name;

        if (studentUpdateRequest.LastName != string.Empty) obj.LastName = studentUpdateRequest.LastName;

        if (studentUpdateRequest.Email != string.Empty) obj.Email = studentUpdateRequest.Email;

        if (studentUpdateRequest.UserName != string.Empty) obj.UserName = studentUpdateRequest.UserName;

        _studentRepository.Update(obj);

    }

    public void Delete(int id)
    {
        var obj = _studentRepository.GetById(id);

        if (obj == null)
            throw new NotFoundException(nameof(Subject), id);

        _studentRepository.Delete(obj);
    }
}
