using backend.backend.Core.Entities;
using backend.backend.Core.Interfaces;
using backend.backend.Core.Interfaces.IServices;

namespace backend.backend.Core.Services
{
  public class SubjectService : BaseService<Subject>, ISubjectService
  {
    public SubjectService(IBaseRepository<Subject> repository) : base(repository)
    {
    }
  }
}