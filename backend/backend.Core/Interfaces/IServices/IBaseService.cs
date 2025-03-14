namespace backend.backend.Core.Interfaces
{
  public interface IBaseService<T> where T : class
  {
    Task<IEnumerable<T>> GetAll();
    Task<T> GetById(int id);
    Task<bool> Delete(int id);
  }
}