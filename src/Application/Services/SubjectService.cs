using ConsultaAlumnos.Application.Interfaces;
using ConsultaAlumnos.Application.Models.Requests;
using ConsultaAlumnos.Domain.Entities;
using ConsultaAlumnos.Domain.Exceptions;
using ConsultaAlumnos.Domain.Interfaces;

namespace ConsultaAlumnos.Application.Services;

public class SubjectService : ISubjectService
{
    private readonly ISubjectRepository _subjectRepository;
    public SubjectService(ISubjectRepository subjectRepository)
    {
        _subjectRepository = subjectRepository;
    }

    public List<Subject> GetAll()
    {
        return _subjectRepository.GetAll();
    }

    public Subject GetById(int id)
    {
        return _subjectRepository.GetById(id);
    }

    public string Create(SubjectCreateRequest subjectCreateRequest)
    {
        var obj = new Subject(subjectCreateRequest.Name);
        if (_subjectRepository.AlreadyCreated(obj.Name))
        {
            return "esa materia ya existe";
        }else
        {
            _subjectRepository.Add(obj);
            return "agregado correctamente";
        }
        
        
    }

    public void Update(int id, SubjectUpdateRequest subjectUpdateRequest)
    {
        var obj = _subjectRepository.GetById(id);

        obj.Name = subjectUpdateRequest.Name;

        _subjectRepository.Update(obj);
    }

    public void Delete(int id)
    {
        var objToDelete = _subjectRepository.GetById(id);

        _subjectRepository.Delete(objToDelete);
    }


}