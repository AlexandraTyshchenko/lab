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
        private readonly IMapper _mapper;


        public SubjectsController(ISubjectCreator subjectCreator, ISubjectsGetter subjectGetter,IMapper mapper)
        {
            _subjectCreator = subjectCreator;
            _subjectGetter = subjectGetter;
            _mapper = mapper;
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
    }
}