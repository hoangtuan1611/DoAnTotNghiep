using backend.backend.Core.Entities;
using backend.backend.Core.Interfaces;
using backend.backend.Core.Interfaces.IServices;

namespace backend.backend.Core.Services
{
  public class TeacherService : BaseService<Teacher>, ITeacherService
  {
    public TeacherService(IBaseRepository<Teacher> repository) : base(repository)
    {
    }
  }
}