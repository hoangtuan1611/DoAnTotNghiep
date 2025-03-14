using AutoMapper;
using backend.backend.Core.DTOs;
using backend.backend.Core.Entities;
using backend.backend.Core.Interfaces.IServices;
using Microsoft.AspNetCore.Mvc;

namespace backend.backend.Api.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class SubjectController : BaseController<Subject, ISubjectService, SubjectDto>
  {
    public SubjectController(ISubjectService service, IMapper mapper) : base(service, mapper)
    {
    }
  }
}