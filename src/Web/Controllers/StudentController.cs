using ConsultaAlumnos.Application.Interfaces;
using ConsultaAlumnos.Application.Models.Requests;
using ConsultaAlumnos.Application.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ConsultaAlumnos.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        readonly IStudentService _studenService;
        public StudentController(IStudentService studenService)
        {
            _studenService = studenService;
        }
        [HttpGet] 
        public IActionResult GetAll()
        {
            return Ok(_studenService.GetAll());
        }
        [HttpGet("[action]")]
        public IActionResult GetFullData()
        {
            return Ok(_studenService.GetAllFullData());
        }
        [HttpGet ("{id}")]
        public IActionResult GetById([FromRoute]int id)
        {
            return Ok(_studenService.GetById(id));
        }
        [HttpPost]
        public IActionResult Create([FromBody] StudentCreateRequest studentCreateRequest)
        {
            var newObject = _studenService.Create(studentCreateRequest);
            return CreatedAtAction(nameof(GetById), new { id = newObject.Id }, newObject);
        }
        [HttpPut("{id}")]
        public IActionResult Update([FromRoute]int id, [FromBody] StudentUpdateRequest studentUpdateRequest)
        {
            _studenService.Update(id, studentUpdateRequest);
            return NoContent();
        }
        [HttpDelete ("{id}")]
        public IActionResult Delete([FromRoute]int id)
        {
            _studenService.Delete(id);
            return NoContent();
        }
    }
}
