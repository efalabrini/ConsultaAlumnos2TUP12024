using ConsultaAlummos2TUP12024.Domain.Interfaces;

namespace ConsultaAlummos2TUP12024.Application.Services;

public class SubjectService
{
    public readonly ISubjectRepository _subjectRepository;
    public SubjectService(ISubjectRepository subjectRepository)
    {
        _subjectRepository = subjectRepository;
    }
}