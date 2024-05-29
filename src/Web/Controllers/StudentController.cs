using ConsultaAlumnos.Application.Interfaces;
using ConsultaAlumnos.Application.Models;
using ConsultaAlumnos.Application.Models.Requests;
using ConsultaAlumnos.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace ConsultaAlumnos.Web.Controllers
{
    public class StudentController : Controller
    {
        private readonly IStudentService _studentservice;

        public StudentController (IStudentService studentservice)
        {
            _studentservice = studentservice;
        }

        [HttpPost("[action]")]
        public IActionResult Create([FromBody] StudentCreateRequest studentCreateRequest)
        {
            var obj = _studentservice.Create(studentCreateRequest);
            return CreatedAtAction(nameof(GetById), new { id = obj.Id } );
        }

        [HttpGet("{id}")]
        public ActionResult<StudentDto> GetById([FromRoute] int id)
        {
            return Ok( _studentservice.GetById(id));
        }

        [HttpGet("[action]")]
        public ActionResult<List<StudentDto>> GetAll()
        {
            return Ok(_studentservice.GetAll());
        }

        [HttpPut("{id}")]
        public IActionResult Update([FromRoute] int id, [FromBody] StudentUpdateRequest studentUpdateRequest)
        {
            _studentservice.Update(id, studentUpdateRequest);
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete([FromRoute] int id)
        {
            _studentservice.Delete(id);
            return Ok();
        }

        [HttpGet("[action]")]
        public ActionResult<Student> GetAllFullData()
        {
            return Ok(_studentservice.GetAllFullData());
        }
    }
}
