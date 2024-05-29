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
        [HttpPost("[action]")]
        public ActionResult<Student> create([FromBody] StudentCreateRequest studentCreateRequest)
        {
            var obj = _studentService.Create(studentCreateRequest);
            return Ok(obj);
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            try
            {
                _studentService.Delete(id); ;
                return NoContent();
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }

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
        public ActionResult<SubjectDto> GetById(int id)
        {
            return Ok(_studentService.GetById(id));
        }

        [HttpPut("{id}")]
        public IActionResult Update([FromRoute] int id, [FromBody] StudentUpdateRequest studentUpdateRequest)
        {
            try
            {
                _studentService.Update(id, studentUpdateRequest);
                return NoContent();
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
