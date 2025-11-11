using ContactsAPI_V2.Model.DTO;

namespace ContactsAPI_V2.Services.Interfaces
{
    public interface IContactService
    {
        public Task<IEnumerable<ContactDTO>> GetAllContacts();
        public Task<ContactDTO> GetContactById(int id);
        public Task<ContactDTO> CreateContact(ContactCreateDTO contact);
        public Task DeleteContact(int id);
    }
}
