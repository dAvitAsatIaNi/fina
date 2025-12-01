using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

[ApiController]
[Route("api/[controller]")]
public class GroupsController : Controller
{
    private readonly IGroupService _groupService;

    public GroupsController(IGroupService groupService)
    {
        _groupService = groupService;
    }

    [HttpPost("add-group")]
    public async Task<IActionResult> AddGroup([FromBody] Group group)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        await _groupService.AddGroupAsync(group);
        
        return Ok(new { Message = "Group created successfully" });
    }
    
    [HttpPut("edit-group")]
    public async Task<IActionResult> UpdateGroup([FromBody] Group group)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        await _groupService.UpdateGroupAsync(group);
        
        return Ok(new { Message = "Group updated successfully" });
    }
    
    [HttpDelete("delete-group/{id}")]
    public async Task<IActionResult> DeleteGroup(int id)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);
        
        await _groupService.DeleteGroupAsync(id);
        
        return Ok(new { Message = "Group deleted successfully" });
    }
    
    [HttpGet]
    public async Task<IActionResult> GetGroups()
    {
        var groups = await _groupService.GetGroupsAsync();
        return Ok(groups);
    }
    
    [HttpGet("get-group-by-id/{id}")]
    public async Task<IActionResult> GetGroupById(int id)
    {
        var product = await _groupService.GetGroupByIdAsync(id);
        return Ok(product);
    }
}