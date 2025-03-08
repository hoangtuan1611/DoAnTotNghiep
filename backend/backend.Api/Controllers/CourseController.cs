using AutoMapper;
using backend.backend.Core.DTOs;
using backend.backend.Core.Entities;
using backend.backend.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace backend.backend.Api.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class CourseController : BaseController<Course, ICourseService, CourseDto>
  {
    private readonly ICourseService _service;

    public CourseController(ICourseService service, IMapper mapper) : base(service, mapper)
    {
      _service = service;
    }

    [HttpGet("by-lecturer")]
    public async Task<IActionResult> GetByLecturerId([FromQuery] int lecturerId)
    {
      var result = await _service.GetCoursesByLecturerId(lecturerId);
      return Ok(result);
    }
  }
}