using AutoMapper;
using backend.backend.Core.DTOs;
using backend.backend.Core.Entities;
using backend.backend.Core.Interfaces.IServices;
using Microsoft.AspNetCore.Mvc;

namespace backend.backend.Api.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class AttendanceLogController : BaseController<AttendanceLog, IAttendanceLogService, AttendaceLogDto>
  {
    private readonly IAttendanceLogService _service;

    public AttendanceLogController(IAttendanceLogService service, IMapper mapper) : base(service, mapper)
    {
      _service = service;
    }

    [HttpGet("by-scheduleId")]
    public async Task<IActionResult> GetAllByScheduleId(int scheduleId)
    {
      var result = await _service.GetByScheduleId(scheduleId);
      if (result == null)
      {
        return BadRequest("Can't get attendance log!");
      }
      return Ok(result);
    }
  }
}