using ConsultaAlumnos.Application.Interfaces;
using ConsultaAlumnos.Application.Models;
using ConsultaAlumnos.Application.Models.Requests;
using ConsultaAlumnos.Domain.Entities;
using ConsultaAlumnos.Domain.Exceptions;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace ConsultaAlumnos.Web.Controllers
{
    public class StudentController : Controller
    {
        private readonly IStudentService _studentService;

        public StudentController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        [HttpGet("[action]")]
        public ActionResult<List<StudentDto>> GetAllStudents()
        {
            try
            {
                return _studentService.GetAll();
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex);
            }
        }

        [HttpGet("[action]")]
        public ActionResult<List<Student>> GetAllStudentsFullData()
        {
            try
            {
                return _studentService.GetAllFullData();
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex);
            }
        }

        [HttpGet("[action]/{id}")]
        public ActionResult<StudentDto> GetStudentById(int id)
        {
            try
            {
                return _studentService.GetById(id);
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex);
            }
        }

        [HttpPost("[action]")]
        public ActionResult<Student> CreateStudent([FromBody]StudentCreateRequest student)
        {
            try
            {
                return _studentService.Create(student);
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex);
            }
        }

        [HttpPut("[action]/{id}")]
        public IActionResult UpdateStudent(int id, [FromBody] StudentUpdateRequest student) 
        {
            try
            {
                _studentService.Update(id, student);
                return NoContent();
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex);
            }
        }

        [HttpDelete("[action]/{id}")]
        public IActionResult DeleteStudent(int id)
        {
            try
            {
                _studentService.Delete(id);
                return NoContent();
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex);
            }
        }
    }
}
