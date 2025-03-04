using backend.backend.Core.Interfaces;

namespace backend.backend.Core.Services
{
  public class BaseService<T> : IBaseService<T> where T : class
  {
    private readonly IBaseRepository<T> _repository;

    public BaseService(IBaseRepository<T> repository)
    {
      _repository = repository;
    }

    public async Task<IEnumerable<T>> GetAll()
    {
      return await _repository.GetAllAsync();
    }

    public async Task<T> GetById(int id)
    {
      return await _repository.GetByIdAsync(id);
    }

    public virtual async Task<bool> Update(int id, T model)
    {
      await Task.CompletedTask;
      throw new NotImplementedException();
    }

    public async Task<bool> Create(T model)
    {
      await _repository.AddAsync(model);
      return true;
    }

    public async Task<bool> Delete(int id)
    {
      var model = await _repository.GetByIdAsync(id);
      if (model != null)
      {
        await _repository.DeleteAsync(id);
        return true;
      }
      return false;
    }
  }
}