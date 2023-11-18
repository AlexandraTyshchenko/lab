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

        public StudentsController( IStudentsGetter studentsGetter)
        {
            _studentsGetter= studentsGetter;
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

    }
}
