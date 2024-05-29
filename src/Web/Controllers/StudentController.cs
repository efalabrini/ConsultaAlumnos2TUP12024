using ConsultaAlumnos.Application.Interfaces;
using ConsultaAlumnos.Application.Models;
using ConsultaAlumnos.Application.Models.Requests;
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

        [HttpPost]
        public IActionResult Create(StudentCreateRequest studentCreateRequest)
        {
            var newObj = _studentService.Create(studentCreateRequest);
            return CreatedAtAction(nameof(GetById), new { id = newObj.Id }, newObj);

        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody]StudentUpdateRequest studentUpdateRequest)
        {
            try
            {
                _studentService.Update(id, studentUpdateRequest);
                return Ok();
            }
            catch (NotFoundException)
            {
                return NoContent();
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _studentService.Delete(id);
                return Ok();
            }
            catch (NotFoundException)
            {
                return NoContent();
            }
        }
        


    }
}
