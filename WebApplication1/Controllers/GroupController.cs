using Microsoft.AspNetCore.Mvc;
using WebApplication1.Interfaces;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GroupController : ControllerBase
    {
        private IGroupCreator _groupCreator;
        public GroupController(IGroupCreator groupCreator)
        {
            _groupCreator = groupCreator;
        }

        [HttpPost]
        public async Task<IActionResult> CreateGroup(string groupName, int groupCourse, string groupCurator)
        {
           await _groupCreator.CreateGroup(groupName, groupCourse, groupCurator);
            return Ok();
        }
    }
}
