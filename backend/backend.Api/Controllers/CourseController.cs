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
    public CourseController(ICourseService service, IMapper mapper) : base(service, mapper)
    {
    }
  }
}