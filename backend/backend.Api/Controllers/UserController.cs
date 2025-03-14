using AutoMapper;
using backend.backend.Core.DTOs;
using backend.backend.Core.Entities;
using backend.backend.Core.Interfaces.IServices;
using Microsoft.AspNetCore.Mvc;

namespace backend.backend.Api.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class UserController : BaseController<User, IUserService, UserDto>
  {
    private readonly IUserService _service;

    public UserController(IUserService service, IMapper mapper) : base(service, mapper)
    {
      _service = service;
    }

    [HttpPost("Create")]
    public async Task<IActionResult> CreateUser([FromBody] UserDto userDto)
    {
      var result = await _service.CreateUser(userDto.Username, userDto.Password, userDto.TeacherCode);
      return result ? Ok("Create user success") : BadRequest(" Fail to create user");
    }

    [HttpPost("Auth")]
    public async Task<IActionResult> ValidUser([FromBody] UserDto userDto)
    {
      var (token, teacherCode, teacherName) = await _service.ValidUser(userDto.Username, userDto.Password);
      if (token == null)
      {
        return Unauthorized(new { message = "Invalid credentials" });
      }
      return Ok(new { token, teacherCode, teacherName });
    }
  }
}