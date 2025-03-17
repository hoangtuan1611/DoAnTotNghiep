using AutoMapper;
using backend.backend.Core.DTOs;
using backend.backend.Core.Entities;
using backend.backend.Core.Interfaces.IServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace backend.backend.Api.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class ClassController : BaseController<Class, IClassService, ClassDto>
  {
    private readonly IClassService _service;
    private readonly IMapper _mapper;

    public ClassController(IClassService service, IMapper mapper) : base(service, mapper)
    {
      _service = service;
      _mapper = mapper;
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateClass(int id, ClassDto dto)
    {
      if (dto == null)
      {
        return BadRequest();
      }
      if (!ModelState.IsValid)
      {
        return BadRequest(ModelState);
      }
      try
      {
        var convertResult = _mapper.Map<Class>(dto);
        var result = await _service.Update(id, convertResult);
        return result ? Ok("Updated") : BadRequest("Check again your body or Id");
      }
      catch (DbUpdateException ex)
      {
        return BadRequest("Database update error: " + ex.Message);
      }
      catch (Exception ex)
      {
        return StatusCode(500, "An error occurred: " + ex.Message);
      }
    }
  }
}