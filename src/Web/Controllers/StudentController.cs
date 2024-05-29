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

        [HttpPost]
        public IActionResult Create([FromBody] StudentCreateRequest studentCreateRequest)
        {
            var newObj = _studentService.Create(studentCreateRequest);

            return Ok(newObj);
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

        [HttpDelete("{id}")]
        public IActionResult Delete([FromRoute] int id)
        {
            try
            {
                _studentService.Delete(id);
                return NoContent();
            }

            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpGet]
        public ActionResult<List<StudentDto>> Get()
        {
            return _studentService.GetAll();
        }

        [HttpGet("{id}")]
        public ActionResult<StudentDto> GetById(int id)
        {
            try
            {
                return _studentService.GetById(id);
            }

            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpGet("[action]")]
        public ActionResult<List<Student>> GetAllData()
        {
            return _studentService.GetAllFullData();
        }
    }
}