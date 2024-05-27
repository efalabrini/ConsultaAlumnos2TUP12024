using System.ComponentModel.DataAnnotations;

namespace ConsultaAlumnos.Domain.Entities;

public class Subject
{
    public int Id { get; set; }

    public string Name { get; set; }

    public string MainTeacherEmail { get; set; } = string.Empty;
    public Subject(string name)
    {
        Name = name;
    }
}

