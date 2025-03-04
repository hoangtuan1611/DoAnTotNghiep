using AutoMapper;
using backend.backend.Core.DTOs;
using backend.backend.Core.Entities;
using backend.backend.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace backend.backend.Api.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class AttendanceLogController : BaseController<AttendanceLog, IAttendanceLogService, AttendanceLogDto>
  {
    public AttendanceLogController(IAttendanceLogService service, IMapper mapper) : base(service, mapper)
    {
    }
  }
}