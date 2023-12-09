using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.dbContext;
using WebApplication1.DTOs;
using WebApplication1.entities;

namespace WebApplication1.Mapper
{
    public class MapperConfig : Profile
    {
        public MapperConfig()
        {
            CreateMap<Group, GroupModel>();
            CreateMap<Teacher, TeacherModel>()
                 .ForMember(dest => dest.Subjects, opt => opt.MapFrom(src => src.Subjects.Select(st => st.Subject.Name)));
            CreateMap<Subject, SubjectModel>();
            CreateMap<Teacher, TeacherModelWithSubjectKeys>()
               .ForMember(dest => dest.Subjects, opt => opt.MapFrom(src => src.Subjects.Select(st => st.Subject)));
        }
    }
}
