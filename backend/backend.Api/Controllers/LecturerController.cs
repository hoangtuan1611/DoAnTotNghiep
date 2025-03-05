using AutoMapper;
using backend.backend.Core.DTOs;
using backend.backend.Core.Entities;
using backend.backend.Core.Interfaces;
using backend.backend.Core.Models;
using backend.backend.Core.Services.JWT;
using Microsoft.AspNetCore.Mvc;

namespace backend.backend.Api.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class LecturerController : BaseController<Lecturer, ILecturerService, LecturerDto>
  {
    private readonly ILecturerService _service;
    private readonly IMapper _mapper;
    private readonly JwtService _jwtService;
    public LecturerController(
      ILecturerService service,
      IMapper mapper,
      JwtService jwtService) : base(service, mapper)
    {
      _service = service;
      _mapper = mapper;
      _jwtService = jwtService;
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] User requestUser)
    {
      var user = await _service.ValidateUser(requestUser.Username, requestUser.Password);
      if (!user)
      {
        return Unauthorized(new { message = "Invalid credentials" });
      }
      var token = _jwtService.GenerateToken(requestUser.Username);
      return Ok(new { token });
    }
  }
}