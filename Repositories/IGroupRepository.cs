using System.Collections.Generic;
using System.Threading.Tasks;

public interface IGroupRepository
{
    Task<int> AddGroupAsync(Group group);
    Task<int> UpdateGroupAsync(Group group);
    Task<int> DeleteGroupAsync(int id);
    Task<List<Group>> GetGroupsAsync();

}