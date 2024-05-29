using ConsultaAlumnos.Application.Interfaces;
using ConsultaAlumnos.Application.Models;
using ConsultaAlumnos.Application.Models.Requests;
using ConsultaAlumnos.Domain.Entities;
using ConsultaAlumnos.Domain.Exceptions;
using Microsoft.AspNetCore.Http;
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

        [HttpGet]
        public ActionResult<List<StudentDto>> GetAll()
        {
            try
            {
                return Ok(_studentService.GetAll());
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex);
            }

        }

        [HttpPost]
        public IActionResult Create([FromBody] StudentCreateRequest studentCreateRequest)
        {
            try
            {
                var newStudent = _studentService.Create(studentCreateRequest);
                return Ok(newStudent);
            }
            catch 
            {
                return BadRequest();
            }

        }

        [HttpPut("{id}")]

        public IActionResult Update([FromRoute] int id, [FromBody] StudentUpdateRequest studentUpdateRequest)
        {
            try
            {
                _studentService.Update(id, studentUpdateRequest);
                return Ok();

            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);

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

            catch (NotFoundException ex)
            {
                return NotFound (ex.Message);
            }
        }

        [HttpGet("[action]")]
        public ActionResult <List<Student>> GetAllFullData()
        {
            return Ok (_studentService.GetAllFullData());
        }

        [HttpGet("{id}")]
        public ActionResult <StudentDto> GetById([FromRoute]int id)
        {
            try
            {
                return Ok (_studentService.GetById(id));
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
