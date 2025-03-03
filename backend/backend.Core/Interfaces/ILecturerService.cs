using backend.backend.Core.DTOs;
using backend.backend.Core.Entities;

namespace backend.backend.Core.Interfaces
{
  public interface ILecturerService
  {
    Task<IEnumerable<Lecturer>> GetAllLecturers();
    Task<Lecturer> GetLecturerById(int id);
    Task<bool> CreateLecturer(Lecturer lecturer);
    Task<bool> UpdateLecturer(int id, Lecturer lecturer);
    Task<bool> DeleteLecturer(int id);
  }
}