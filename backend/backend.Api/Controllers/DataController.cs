using backend.backend.Infrastructure.Data;
using backend.backend.Infrastructure.Seeds;
using Microsoft.AspNetCore.Mvc;

namespace backend.backend.Api.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class DataController : ControllerBase
  {
    private readonly ApplicationDbContext _dbcontext;
    private readonly Seeder _seeder;

    public DataController(ApplicationDbContext dbContext, Seeder seeder)
    {
      _dbcontext = dbContext;
      _seeder = seeder;
    }

    [HttpGet]
    public async Task<IActionResult> GetDataJson()
    {
      try
      {
        await _seeder.SeedDataAsync("backend.Infrastructure/Resources/Thang.json", "011.031.00125");
        return Ok();
      }
      catch (System.Exception ex)
      {
        return BadRequest(ex);
      }
    }
  }
}