using AutoMapper;
using backend.backend.Core.DTOs;
using backend.backend.Core.Entities;
using backend.backend.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace backend.backend.Api.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class LecturerController : BaseController<Lecturer, ILecturerService, LecturerDto>
  {
    public LecturerController(ILecturerService service, IMapper mapper) : base(service, mapper)
    {
    }
  }
}