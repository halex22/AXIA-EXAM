using ContactsAPI.Model.DTO;

namespace ContactsAPI.Services.Interfaces
{
    public interface IContactInterface
    {
        public Task<IEnumerable<ContactDTO>> GetContacts();
        public Task<ContactDTO> CreateContact(ContactCreateDTO newContact);
        public Task DeleteContact(int contactId);
        public Task<IEnumerable<ContactDTO>> GetGroupContacts(int groupId);
    }
}
