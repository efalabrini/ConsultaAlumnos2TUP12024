using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsultaAlumnos.Application.Models.Requests;

public class SubjectUpdateRequest
{
    public string Name { get; set; } = string.Empty;

    [EmailAddress]
    public string MainTeacheEmail { get; set; } = string.Empty;
}
