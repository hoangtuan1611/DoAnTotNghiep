using AutoMapper;
using backend.backend.Core.DTOs;
using backend.backend.Core.Entities;
using backend.backend.Core.Interfaces.IServices;
using Microsoft.AspNetCore.Mvc;

namespace backend.backend.Api.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class TeacherController : BaseController<Teacher, ITeacherService, TeacherDto>
  {
    public TeacherController(ITeacherService service, IMapper mapper) : base(service, mapper)
    {
    }
  }
}