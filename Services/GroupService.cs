using System.Threading.Tasks;

public class GroupService : IGroupService
{
    private readonly IGroupRepository _repository;

    public GroupService(IGroupRepository repository)
    {
        _repository = repository;
    }

    public async Task<int> AddGroupAsync(Group group)
    {
        return await _repository.AddGroupAsync(group);
    }
    
    public async Task<int> UpdateGroupAsync(Group group)
    {
        return await _repository.UpdateGroupAsync(group);
    }
    
    public async Task<int> DeleteGroupAsync(int id)
    {
        return await _repository.DeleteGroupAsync(id);
    }
    public async Task<List<Group>> GetGroupsAsync()
    {
        return await _repository.GetGroupsAsync();
    }

    public async Task<List<Group>> GetGroupByIdAsync(int id)
    {
        return await _repository.GetGroupByIdAsync(id);
    }
    
}