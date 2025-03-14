using backend.backend.Core.Entities;
using backend.backend.Core.Interfaces;
using backend.backend.Core.Interfaces.IServices;

namespace backend.backend.Core.Services
{
  public class ClassService : BaseService<Class>, IClassService
  {
    public ClassService(IBaseRepository<Class> repository) : base(repository)
    {
    }
  }
}