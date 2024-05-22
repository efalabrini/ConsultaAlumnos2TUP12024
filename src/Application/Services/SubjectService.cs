using ConsultaAlumnos.Application.Interfaces;
using ConsultaAlumnos.Application.Models;
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

    public List<SubjectDto> GetAll()
    {
        var list = _subjectRepository.GetAll();

        return SubjectDto.CreateList(list);
    }

    public List<Subject> GetAllFullData()
    {
        return _subjectRepository.GetAll();
    }

    public SubjectDto GetById(int id)
    {
        var obj = _subjectRepository.GetById(id)
            ?? throw new NotFoundException(nameof(Subject),id);

        var dto = SubjectDto.Create(obj);

        return dto;
    }

    public Subject Create(SubjectCreateRequest subjectCreateRequest)
    {
        var obj = new Subject(subjectCreateRequest.Name);
        return _subjectRepository.Add(obj);
    }

    public void Update(int id, SubjectUpdateRequest subjectUpdateRequest)
    {
        ///Option 1 (Only affected fields are updated)
        var obj = _subjectRepository.GetById(id); //The context starts to track changes.

        if (obj == null)
            throw new NotFoundException(nameof(Subject), id);

        if (subjectUpdateRequest.Name != string.Empty) obj.Name = subjectUpdateRequest.Name;

        if (subjectUpdateRequest.MainTeacheEmail != string.Empty) obj.MainTeacherEmail = subjectUpdateRequest.MainTeacheEmail;

        _subjectRepository.SaveChanges();


        ///Option 2 (The entity is updated completely)
        /*
        Subject subject = new Subject(subjectUpdateRequest.Name);
        subject.Id = id;
        subject.MainTeacherEmail = subjectUpdateRequest.MainTeacheEmail;
        _subjectRepository.Update(subject); // Context.update starts to track changes of an existing entity.
        */
    }

    public void Delete(int id)
    {
        var objToDelete = _subjectRepository.GetById(id);

        _subjectRepository.Delete(objToDelete);
    }

}