using System.Text;
using backend.backend.Core.Interfaces;
using backend.backend.Core.Services;
using backend.backend.Core.Services.JWT;
using backend.backend.Infrastructure.Data;
using backend.backend.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

var key = "this_is_a_very_secure_and_long_secret_key_1234567890!";

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
  options.UseSqlServer(builder.Configuration.GetConnectionString("Default"));
});

builder.Services.AddScoped(typeof(IBaseService<>), typeof(BaseService<>));
builder.Services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
builder.Services.AddScoped<ILecturerService, LecturerService>();
builder.Services.AddScoped<ICourseService, CourseService>();
builder.Services.AddScoped<IClassService, ClassService>();
builder.Services.AddScoped<IAttendanceLogService, AttendanceLogService>();

builder.Services.AddAutoMapper(typeof(Program));

builder.Services.AddCors(options =>
{
  options.AddPolicy("AllowFrontend",
    policy => policy.WithOrigins("http://localhost:5173")
                    .AllowAnyMethod()
                    .AllowAnyHeader());
});

builder.Services.AddSingleton(new JwtService(key));
builder.Services.AddScoped<ILecturerService, LecturerService>();

builder.Services.AddAuthentication("Bearer")
    .AddJwtBearer(options =>
    {
      options.TokenValidationParameters = new TokenValidationParameters
      {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(key)),
        ValidateIssuer = false,
        ValidateAudience = false
      };
    });

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
  app.UseSwagger();
  app.UseSwaggerUI();
  app.MapOpenApi();
}

app.UseCors("AllowFrontend");
app.MapControllers();
app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.UseStatusCodePages();
app.Run();
