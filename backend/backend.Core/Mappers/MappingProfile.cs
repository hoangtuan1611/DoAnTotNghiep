using AutoMapper;
using backend.backend.Core.DTOs;
using backend.backend.Core.Entities;

namespace backend.backend.Core.Mappers
{
  public class MappingProfile : Profile
  {
    public MappingProfile()
    {
      CreateMap<Teacher, TeacherDto>().ReverseMap();
      CreateMap<Class, ClassDto>().ReverseMap();
      CreateMap<Subject, SubjectDto>().ReverseMap();
      CreateMap<User, UserDto>().ReverseMap();

      CreateMap<Schedule, ScheduleDto>()
        .ForMember(dest => dest.ClassName, opt => opt.MapFrom(src => src.Class.ClassName))
        .ForMember(dest => dest.MaxStudents, opt => opt.MapFrom(src => src.Class.MaxStudents));

      CreateMap<TimeTableDto, TimeTable>()
          .ForMember(dest => dest.Schedule, opt => opt.Ignore());

      CreateMap<TimeTable, TimeTableDto>()
          .ForMember(dest => dest.Schedule, opt => opt.MapFrom(src => src.Schedule))
          .ForMember(dest => dest.Subject, opt => opt.MapFrom(src => src.Subject));

      CreateMap<TimeTableDto, TimeTable>()
          .ForMember(dest => dest.Schedule, opt => opt.Ignore())
          .ForMember(dest => dest.Subject, opt => opt.Ignore());
    }
  }
}