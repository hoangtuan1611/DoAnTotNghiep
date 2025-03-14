using AutoMapper;
using backend.backend.Core.DTOs;
using backend.backend.Core.Entities;
using backend.backend.Core.Interfaces.IServices;
using Microsoft.AspNetCore.Mvc;

namespace backend.backend.Api.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class TimeTableController : BaseController<TimeTable, ITimeTableService, TimeTableDto>
  {
    private readonly ITimeTableService _service;
    private readonly IMapper _mapper;

    public TimeTableController(ITimeTableService service, IMapper mapper) : base(service, mapper)
    {
      _service = service;
      _mapper = mapper;
    }

    [HttpGet("Teacher/{id}")]
    public async Task<IActionResult> GetByTeacherId(string id)
    {
      var result = await _service.GetTeacher(id);
      var resultDtos = _mapper.Map<IEnumerable<TimeTableDto>>(result);
      return Ok(resultDtos);
    }
  }
}