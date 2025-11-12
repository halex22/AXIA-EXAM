using ContactsAPI_V2.Model.DTO;

namespace ContactsAPI_V2.Services.Interfaces
{
    public interface IGroupService
    {
        public Task<IEnumerable<ContactDTO>> GetGroupContacts(int groupId);
        public Task<GroupDTO> CreateGroup(GroupCreateTDO group);
        public Task AddContactToGroup(int ContactId, int groupId);
        public Task<IEnumerable<GroupDTO>> GetAllGroups();
    }
}
