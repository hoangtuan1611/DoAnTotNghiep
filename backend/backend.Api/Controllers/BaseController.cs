using AutoMapper;
using backend.backend.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

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

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
      var result = await _service.Delete(id);
      return result ? Ok() : BadRequest();
    }
  }
}