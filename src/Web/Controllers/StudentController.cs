using ConsultaAlumnos.Application.Interfaces;
using ConsultaAlumnos.Application.Models.Requests;
using ConsultaAlumnos.Application.Models;
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
            return CreatedAtAction(nameof(Get), new { id = newObj.Id }, newObj);
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

        [HttpGet("{id}")]
        public ActionResult<StudentDto> Get([FromRoute] int id)
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


    }

}
