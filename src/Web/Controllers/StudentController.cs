using ConsultaAlumnos.Application.Interfaces;
using ConsultaAlumnos.Application.Models;
using ConsultaAlumnos.Application.Models.Requests;
using ConsultaAlumnos.Application.Services;
using ConsultaAlumnos.Domain.Entities;
using ConsultaAlumnos.Domain.Exceptions;
using Microsoft.AspNetCore.Mvc;

namespace ConsultaAlumnos.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService _studentService;
        public StudentController(IStudentService studentService)
        {
            _studentService = studentService;
        }


        [HttpPost("[action]")]
        public ActionResult<Student> create([FromBody] StudentCreateRequest studentCreateRequest)
        {
            var obj = _studentService.Create(studentCreateRequest);
            return Ok(obj);
        }

        [HttpGet("[action]")]
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
        public ActionResult<SubjectDto> GetById(int id)
        {
            return Ok(_studentService.GetById(id));
        }

        [HttpPut("{id}")]
        public IActionResult Update([FromRoute] int id, [FromBody] StudentUpdateRequest studentUpdateRequest)
        {
             _studentService.Update(id, studentUpdateRequest);
             return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            _studentService.Delete(id); ;
            return NoContent();
        }
    }
}