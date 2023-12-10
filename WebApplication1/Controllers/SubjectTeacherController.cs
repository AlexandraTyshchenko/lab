using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.DTOs;
using WebApplication1.Interfaces;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubjectTeacherController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ISubjectTeacherProvider _subjectTeacherProvider;

        public SubjectTeacherController(IMapper mapper, ISubjectTeacherProvider subjectTeacherProvider)
        {
            _mapper = mapper;
            _subjectTeacherProvider = subjectTeacherProvider;
        }

        [HttpGet]
        public async Task<IActionResult> GetSubjectTeachers()
        {
            var result =  await  _subjectTeacherProvider.GetSubjectTeachersAsync();
            var subjectTeachers = _mapper.Map<List<SubjectTeacherModel>>(result);
            return Ok(subjectTeachers);
        }
    }
}
