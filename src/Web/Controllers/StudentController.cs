using ConsultaAlumnos.Application.Interfaces;
using ConsultaAlumnos.Application.Models;
using ConsultaAlumnos.Application.Models.Requests;
using ConsultaAlumnos.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ConsultaAlumnos.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService _studentService;

        public StudentController(IStudentService studentServices)
        {
            _studentService = studentServices;
        }

        [HttpPost]
        public IActionResult Create([FromBody] StudentCreateRequest studentCreateRequest)
        {
            var obj = _studentService.Create(studentCreateRequest);
            return CreatedAtAction(nameof(Get), new { id = obj.Id }, obj);
        }

        [HttpGet("{id}")]
        public ActionResult<StudentDto> Get([FromRoute]int id)
        {
            try
            {
                var obj = _studentService.GetById(id);
                return Ok(obj);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
        [HttpGet("[action]")]
        public ActionResult<List<Student>> GetFullData()
        {
            var obj = _studentService.GetAllFullData();
            return Ok(obj);
        }

        [HttpGet("[action]")]
        public ActionResult<List<StudentDto>> GetAll()
        {
            return _studentService.GetAll();
        }

        [HttpPut("{id}")]
        public ActionResult Update([FromRoute] int id,[FromBody] StudentUpdateRequest studentUpdateRequest)
        {
            try
            {
                _studentService.Update(id, studentUpdateRequest);
                return NoContent();
            }
            catch (Exception ex)
            {
                return NotFound(ex);
            }

        }

        [HttpDelete("{id}")]
        public ActionResult Delete([FromRoute] int id)
        {
            try
            {
            _studentService.Delete(id);
            return NoContent();
            }
            catch (Exception ex)
            {
                return NotFound(ex);
            }
        }
    }
}
