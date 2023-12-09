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

            //CreateMap<Lesson, Schedule>()
            //    .BeforeMap((src, dest, context) =>
            //    {
            //        if (src.SubjectTeacherId != null)
            //        {
            //            var subjectTeacher = _dbContext.SubjectTeachers.FirstOrDefault(st => st.Id == src.SubjectTeacherId);
            //            if (subjectTeacher != null)
            //            {
            //                dest.SubjectTeacher = subjectTeacher;
            //            }
            //        }
            //    });
            CreateMap<Group, GroupModel>();
            CreateMap<Teacher, TeacherModel>()
                 .ForMember(dest => dest.Subjects, opt => opt.MapFrom(src => src.Subjects.Select(st => st.Subject.Name)));
            CreateMap<Subject, SubjectModel>();
        }
    }
}
