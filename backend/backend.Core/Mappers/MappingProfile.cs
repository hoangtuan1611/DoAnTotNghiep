using AutoMapper;
using backend.backend.Core.DTOs;
using backend.backend.Core.Entities;

namespace backend.backend.Core.Mappers
{
  public class MappingProfile : Profile
  {
    public MappingProfile()
    {
      CreateMap<Lecturer, LecturerDto>();
      CreateMap<LecturerDto, Lecturer>();
      CreateMap<StudyClass, ClassDto>();
      CreateMap<ClassDto, StudyClass>();
      CreateMap<Course, CourseDto>();
      CreateMap<CourseDto, Course>();
      CreateMap<AttendanceLog, AttendanceLogDto>();
      CreateMap<AttendanceLogDto, AttendanceLog>();
    }
  }
}