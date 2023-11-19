using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using WebApplication1.DTOs;
using WebApplication1.entities;
using WebApplication1.Interfaces;
using WebApplication1.Services;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly IStudentsGetter _studentsGetter;
        private readonly IStudentCreator _studentsCreator;

        public StudentsController( IStudentsGetter studentsGetter,IStudentCreator  studentCreator)
        {
            _studentsGetter= studentsGetter;
            _studentsCreator= studentCreator;
        }

        [HttpGet]
        public async Task<IActionResult> GetStudents(
            [FromQuery, Required] int groupId,
            [FromQuery, Required] int page,
            [FromQuery, Required] int pageSize)
        {
            var result = await _studentsGetter.GetStudentsAsync(groupId, page, pageSize);
            var response = new
            {
                Students = result,
                StudentsCount = _studentsGetter.StudentsCount
            };
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> AddStudents(
         [FromForm,Required] string firstName, [FromForm, Required] string lastName, [FromForm, Required] int groupId, [FromForm, Required] string email)
        {
            await _studentsCreator.AddStudent(firstName, lastName, groupId, email);

            return Ok();
        }

    }
}
