using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

public class GroupRepository : IGroupRepository
{
    private readonly AppDbContext _context;

    public GroupRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<int> AddGroupAsync(Group group)
    {
        return await _context.Database.ExecuteSqlInterpolatedAsync(
            $"EXEC fina.AddGroup {group.Name}, {group.ParentId}");
    }
    
    public async Task<int> UpdateGroupAsync(Group group)
    {
        return await _context.Database.ExecuteSqlInterpolatedAsync(
            $"EXEC fina.UpdateGroup {group.Id}, {group.Name}, {group.ParentId}");
    }
    
    public async Task<int> DeleteGroupAsync(int id)
    {
        return await _context.Database.ExecuteSqlInterpolatedAsync(
            $"EXEC fina.DeleteGroup {id}");
    }
    
    public async Task<List<Group>> GetGroupsAsync()
    {
        return await _context.Groups
            .FromSqlInterpolated($"EXEC fina.GetGroups")
            .ToListAsync();
    }
}