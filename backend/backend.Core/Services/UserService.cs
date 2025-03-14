using backend.backend.Core.Entities;
using backend.backend.Core.Interfaces;
using backend.backend.Core.Interfaces.IServices;
using backend.backend.Core.Services.JWT;

namespace backend.backend.Core.Services
{
  public class UserService : BaseService<User>, IUserService
  {
    private readonly IBaseRepository<User> _repository;
    private readonly IBaseRepository<Teacher> _teacher;
    private readonly JwtService _jwtService;

    public UserService(
      IBaseRepository<User> repository,
      IBaseRepository<Teacher> teacher,
      JwtService jwtService) : base(repository)
    {
      _repository = repository;
      _teacher = teacher;
      _jwtService = jwtService;
    }

    public async Task<bool> CreateUser(string username, string password, string teacherCode, string role = "Teacher")
    {
      var result = await _repository.FindAsync(u => u.Username == username);
      if (result.Any()) return false;
      if (password.Length < 8) return false;
      string hashPassword = BCrypt.Net.BCrypt.HashPassword(password);
      var validRoles = new List<string> { "Teacher", "Admin" };
      if (!validRoles.Contains(role)) role = "Teacher";
      var user = new User
      {
        TeacherCode = teacherCode,
        Username = username,
        PasswordHash = hashPassword,
        Role = role
      };
      await _repository.AddAsync(user);
      await _repository.SaveAsync();
      return true;
    }

    public async Task<(string Token, string TeacherCode, string TeacherName)> ValidUser(string username, string password)
    {
      var users = await _repository.FindAsync(u => u.Username == username);
      if (!users.Any()) return (null, null, null);
      var foundUser = users.First();
      if (!BCrypt.Net.BCrypt.Verify(password, foundUser.PasswordHash)) return (null, null, null);
      var teacher = await _teacher.FindAsync(t => t.TeacherCode == foundUser.TeacherCode);
      string teacherName = teacher.FirstOrDefault()?.TeacherName ?? "Unknown";
      string token = _jwtService.GenerateToken(foundUser.Username, foundUser.TeacherCode, foundUser.Role);
      return (token, foundUser.TeacherCode, teacherName);
    }
  }
}