using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.DTOs;
using WebApplication1.entities;
using WebApplication1.Interfaces;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GroupController : ControllerBase
    {
        private readonly IGroupCreator _groupCreator;
        private readonly IGroupGetter _groupGetter;
        private readonly IMapper _mapper;

        public GroupController(IGroupCreator groupCreator, IGroupGetter groupGetter,IMapper mapper)
        {
            _groupCreator = groupCreator;
            _groupGetter = groupGetter;
            _mapper = mapper;

        }

        [HttpPost]
        public async Task<IActionResult> CreateGroup(string groupName, int groupCourse, string groupCurator)
        {
           await _groupCreator.CreateGroup(groupName, groupCourse, groupCurator);
            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> GetGroups()
        {
            var result =await _groupGetter.GetGroupsAsync();
            var groups = _mapper.Map<List<GroupModel>>(result);
            return Ok(groups);
        }

       
    }
}
