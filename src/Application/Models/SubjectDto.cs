using ConsultaAlumnos.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ConsultaAlumnos.Application.Models;

public class SubjectDto
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;

    public static SubjectDto Create(Subject subject)
    {
        var dto = new SubjectDto();
        dto.Id = subject.Id;
        dto.Name = subject.Name;

        return dto;
    }

}

