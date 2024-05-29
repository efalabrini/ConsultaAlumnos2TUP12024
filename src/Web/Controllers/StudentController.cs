using ConsultaAlumnos.Application.Interfaces;
using ConsultaAlumnos.Application.Models;
using ConsultaAlumnos.Application.Models.Requests;
using ConsultaAlumnos.Application.Services;
using ConsultaAlumnos.Domain.Entities;
using ConsultaAlumnos.Domain.Exceptions;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SQLitePCL;

namespace ConsultaAlumnos.Web.Controllers;

[Route("api/[controller]")]
[ApiController]
public class StudentController : ControllerBase
{
    private readonly IStudentService _studentService;

    public StudentController(IStudentService studentService)
    {
        _studentService = studentService;
    }

    [HttpGet("[action]")]
    public ActionResult<List<StudentDto>> GetAll()
    {
            return Ok(_studentService.GetAll());
    }

    [HttpGet("[action]")]
    public ActionResult<List<Student>> GetAllFullData()
    {
           return Ok(_studentService.GetAllFullData()); 
    }

    [HttpGet("{id}")]
    public ActionResult GetById([FromRoute]int id)
    {
        try
        {
            var student = _studentService.GetById(id);
            return Ok(student);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }
    }

    [HttpPost]
    public IActionResult Create(StudentCreateRequest studentCreateRequest)
    {
            var newObject = _studentService.Create(studentCreateRequest);
            return Ok(newObject);
    
    }

    [HttpPut("{id}")]
    public IActionResult Update([FromRoute]int id, [FromBody] StudentUpdateRequest studentUpdateRequest)
    {
        try
        {
            _studentService.Update(id,studentUpdateRequest);
            return NoContent();
        }
        catch (NotFoundException)
        {
            return NotFound();
        }
    }

    [HttpDelete("{id}")]
    public IActionResult Delete([FromRoute]int id)
    {
        try
        {
            _studentService.Delete(id);
            return Ok();
        }
        catch (NotFoundException)
        {
            return NotFound();
        }
    }
}