using AutoMapper;
using backend.backend.Core.DTOs;
using backend.backend.Core.Entities;
using backend.backend.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace backend.backend.Api.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class ClassController : BaseController<StudyClass, IClassService, ClassDto>
  {
    public ClassController(IClassService service, IMapper mapper) : base(service, mapper)
    {
    }
  }
}