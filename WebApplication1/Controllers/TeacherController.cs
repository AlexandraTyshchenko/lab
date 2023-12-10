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
        private readonly ISubjectTeacherDeletter _subjectTeacherDeletter;
        private readonly ITeacherDeletter _teacherDeletter;

        public TeacherController(ITeacherCreator teacherCreator, 
            ITeachersGetter teachersGetter, IMapper mapper,
            ISubjectTeacherDeletter subjectTeacherDeletter,
            ITeacherDeletter   teacherDeletter
            )
        {
            _teacherCreator = teacherCreator;
            _teachersGetter = teachersGetter;
            _mapper = mapper;
            _subjectTeacherDeletter= subjectTeacherDeletter;
            _teacherDeletter= teacherDeletter;
        }

        [HttpPost]
        public async Task<IActionResult> AddTeacher([FromForm] string name, [FromForm] string shortInfo)
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

        [HttpGet("id")]
        public async Task<IActionResult> GetTeacherById(int id)
        {
            var result = await _teachersGetter.GetTeacherByID(id);
            var teacher = _mapper.Map<TeacherModelWithSubjectKeys>(result);
            return Ok(teacher);
        }

        [HttpDelete("teacherSubject")]
        public async Task<IActionResult> DeleteSubject([FromQuery] SubjectTeacherParameters subjectTeacherParameters)
        {
            await _subjectTeacherDeletter.DeleteSubjectAsync(subjectTeacherParameters.teacherId, subjectTeacherParameters.subjectId);
            return Ok();
        }

        [HttpDelete("TeacherById")]
        public async Task<IActionResult> DeleteTeacherById(int id)
        {
            await _teacherDeletter.DeleteTeacherAsync(id);
            return Ok();
        }
    }
}
