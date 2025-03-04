using AutoMapper;
using backend.backend.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace backend.backend.Api.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class BaseController<T, TService, TDto> : ControllerBase
    where T : class, IEntity
    where TService : IBaseService<T>
  {
    private readonly TService _service;
    private readonly IMapper _mapper;

    public BaseController(TService service,
     IMapper mapper)
    {
      _service = service;
      _mapper = mapper;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
      var result = await _service.GetAll();
      var resultDtos = _mapper.Map<IEnumerable<TDto>>(result);
      return Ok(resultDtos);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
      var result = await _service.GetById(id);
      if (result == null)
      {
        return NotFound($"Id: {id} not found");
      }
      var resultDto = _mapper.Map<TDto>(result);
      return Ok(resultDto);
    }

    [HttpPost]
    public async Task<IActionResult> SetLecturer(TDto dto)
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
        var convertResult = _mapper.Map<T>(dto);
        var result = await _service.Create(convertResult);
        return result ? CreatedAtAction(nameof(GetById), new { id = convertResult.Id }, dto) : BadRequest("Failed to create");
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

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateLecturer(int id, TDto dto)
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
        var convertResult = _mapper.Map<T>(dto);
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

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
      var result = await _service.Delete(id);
      return result ? Ok() : BadRequest();
    }
  }
}