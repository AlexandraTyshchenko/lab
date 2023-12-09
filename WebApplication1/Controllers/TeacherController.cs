using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.DTOs;
using WebApplication1.Interfaces;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeacherController : ControllerBase
    {
        private readonly ITeacherCreator _teacherCreator;
        private readonly ITeachersGetter _teachersGetter;
        private readonly IMapper _mapper;

        public TeacherController(ITeacherCreator teacherCreator, ITeachersGetter teachersGetter, IMapper mapper)
        {
            _teacherCreator = teacherCreator;
            _teachersGetter = teachersGetter;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> AddTeacher(string name,string shortInfo)
        {
            await _teacherCreator.AddTeacher(name, shortInfo);
            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> GetTeachers()
        {
            var result = await _teachersGetter.GetTeachersAsync();
            var teachers = _mapper.Map<List<TeacherModel>>(result);
            return Ok(teachers);
        }
    }
}
