using AutoMapper;
using backend.backend.Core.DTOs;
using backend.backend.Core.Entities;
using backend.backend.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace backend.backend.Api.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class LecturerController : ControllerBase
  {
    private readonly ILecturerService _lecturerService;
    private readonly IMapper _mapper;

    public LecturerController(
      ILecturerService lecturerService,
      IMapper mapper)
    {
      _lecturerService = lecturerService;
      _mapper = mapper;
    }

    [HttpGet]
    public async Task<IActionResult> GetLecturer()
    {
      var result = await _lecturerService.GetAll();
      var lecturerDtos = _mapper.Map<IEnumerable<LecturerDto>>(result);
      return Ok(lecturerDtos);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetLecturerById(int id)
    {
      var result = await _lecturerService.GetById(id);
      if (result == null)
      {
        return NotFound($"Lecturer with Id: {id} not found");
      }
      var lecturerDto = _mapper.Map<LecturerDto>(result);
      return Ok(lecturerDto);
    }

    [HttpPost]
    public async Task<IActionResult> SetLecturer(LecturerDto lecturerDto)
    {
      if (lecturerDto == null)
      {
        return BadRequest();
      }
      if (!ModelState.IsValid)
      {
        return BadRequest(ModelState);
      }
      try
      {
        var lecturer = _mapper.Map<Lecturer>(lecturerDto);
        var result = await _lecturerService.Create(lecturer);
        return result ? CreatedAtAction(nameof(GetLecturerById), new { id = lecturer.Id }, lecturerDto) : BadRequest("Failed to create lecturer");
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
    public async Task<IActionResult> UpdateLecturer(int id, LecturerDto lecturerDto)
    {
      if (lecturerDto == null)
      {
        return BadRequest();
      }
      if (!ModelState.IsValid)
      {
        return BadRequest(ModelState);
      }
      try
      {
        var lecturer = _mapper.Map<Lecturer>(lecturerDto);
        var result = await _lecturerService.UpdateLecturer(id, lecturer);
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
    public async Task<IActionResult> DeleteLecturer(int id)
    {
      var result = await _lecturerService.Delete(id);
      return result ? Ok() : BadRequest();
    }
  }
}