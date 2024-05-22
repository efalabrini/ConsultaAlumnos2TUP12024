using ConsultaAlumnos.Application.Interfaces;
using ConsultaAlumnos.Application.Models;
using ConsultaAlumnos.Application.Models.Requests;
using ConsultaAlumnos.Domain.Entities;
using ConsultaAlumnos.Domain.Exceptions;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SQLitePCL;

namespace ConsultaAlumnos.Web.Controllers;

[Route("api/[controller]")]
[ApiController]
public class SubjectController : ControllerBase
{
    private readonly ISubjectService _subjectService;
    public SubjectController(ISubjectService subjectService)
    {
        _subjectService = subjectService;
    }

    [HttpPost]
    public IActionResult Create([FromBody] SubjectCreateRequest subjectCreateRequest)
    {
        var newObj = _subjectService.Create(subjectCreateRequest);

        return CreatedAtAction(nameof(Get), new { id = newObj.Id }, newObj);
    }

    [HttpPut("{id}")]
    public IActionResult Update([FromRoute] int id, [FromBody] SubjectUpdateRequest subjectUpdateRequest)
    { 

        try
        {
            _subjectService.Update(id, subjectUpdateRequest);
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
            _subjectService.Delete(id);
            return NoContent();
        }
        catch (NotFoundException ex)
        {
            return NotFound(ex.Message);
        }

    }

    [HttpGet]
    public ActionResult<List<SubjectDto>> GetAll()
    {
        return _subjectService.GetAll();
    }



    [HttpGet("[action]")]
    public ActionResult<List<Subject>> GetAllFullData()
    {
        return _subjectService.GetAllFullData();
    }



    [HttpGet("{id}")]
    public ActionResult<SubjectDto> Get([FromRoute] int id)
    {
        try
        {
            return _subjectService.GetById(id);
        }
        catch (NotFoundException ex)
        {
            return NotFound(ex.Message);
        }
    }

}
