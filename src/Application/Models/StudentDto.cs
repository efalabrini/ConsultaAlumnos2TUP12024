using ConsultaAlumnos.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsultaAlumnos.Application.Models;

public class StudentDto
{
    public int Id { get; set; }

    public string Name { get; set; } = string.Empty;

    public string LastName { get; set; } = string.Empty;

    public static StudentDto Create(Student student)
    {
        var dto = new StudentDto();
        dto.Id = student.Id;
        dto.Name = student.Name;
        dto.LastName = student.LastName;

        return dto;
    }

    public static List<StudentDto> CreateList(IEnumerable<Student> students)
    {
        List<StudentDto> listDto = [];
        foreach (var s in students)
        {
            listDto.Add(Create(s));
        }

        return listDto;
    }
}
