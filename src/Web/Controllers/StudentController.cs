using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ConsultaAlumnos.Application.Interfaces;
using ConsultaAlumnos.Application.Models;
using ConsultaAlumnos.Application.Models.Requests;
using ConsultaAlumnos.Domain.Entities;
using ConsultaAlumnos.Domain.Exceptions;

namespace ConsultaAlumnos.Web;

[Route("api/[controller]")]
[ApiController]
public class StudentController : ControllerBase
{
    private readonly IStudentService _studentService;
    public StudentController(IStudentService studentService)
    {
        _studentService = studentService;
    }

    [HttpPost]
    public IActionResult Create([FromBody] StudentCreateRequest studentCreateRequest)
    {
        var obj = _studentService.Create(studentCreateRequest);
        return CreatedAtAction(nameof(Get), new { id = obj.Id }, obj);
    }

    [HttpPut("{id}")]
    public IActionResult Update([FromRoute] int id, [FromBody] StudentUpdateRequest studentUpdateRequest)
    {
        _studentService.Update(id, studentUpdateRequest);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete([FromRoute] int id)
    {
        _studentService.Delete(id);
        return NoContent();
    }

    [HttpGet]
    public ActionResult<List<StudentDto>> GetAll()
    {
        return _studentService.GetAll();
    }

    [HttpGet("[action]")]
    public ActionResult<List<Student>> GetAllFullData()
    {
        return _studentService.GetAllFullData();
    }

    [HttpGet("{id}")]
    public ActionResult<StudentDto> Get([FromRoute] int id)
    {
        return _studentService.GetById(id);
    }
}
