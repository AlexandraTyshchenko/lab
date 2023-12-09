using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.DTOs;
using WebApplication1.Interfaces;
using WebApplication1.Services;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubjectsController : ControllerBase
    {
        private readonly ISubjectCreator _subjectCreator;
        private readonly ISubjectsGetter _subjectGetter;
        private readonly ISubjectDeletter _subjectDeletter;
        private readonly IMapper _mapper;
        private readonly ISubjectAssignmentToTeacher _subjectAssignmentToTeacher;

        public SubjectsController(ISubjectCreator subjectCreator,
            ISubjectsGetter subjectGetter,IMapper mapper, ISubjectDeletter subjectDeletter, ISubjectAssignmentToTeacher subjectAssignmentToTeacher)
        {
            _subjectCreator = subjectCreator;
            _subjectGetter = subjectGetter;
            _subjectDeletter = subjectDeletter;
            _mapper = mapper;
            _subjectAssignmentToTeacher = subjectAssignmentToTeacher;
        }

        [HttpPost]
        public async Task<IActionResult> AddSubject([FromForm] string name, [FromForm] string description)
        {
            await _subjectCreator.CreateSubject(name, description);
            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> GetSubjects()
        {
            var result = await _subjectGetter.GetSubjectsAsync();
            var subjects = _mapper.Map<List<SubjectModel>>(result);
            return Ok(subjects);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteSubject(int subjectId)
        {
            await _subjectDeletter.DeleteSubjectAsync(subjectId);
            return Ok();
        }

        [HttpPost("AsignSubjectToTeacher")]
        public async Task<IActionResult> AsignSubjectToTeacher([FromForm] int teacherId, [FromForm] int subjectId)
        {
            await _subjectAssignmentToTeacher.AsignSubjectToTeacherAsync(teacherId, subjectId);
            return Ok();
        }
    }
}