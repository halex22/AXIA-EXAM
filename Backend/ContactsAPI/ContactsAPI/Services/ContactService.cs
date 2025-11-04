using ContactsAPI.Model;
using ContactsAPI.Model.DTO;
using ContactsAPI.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ContactsAPI.Services
{
    public class ContactService : IContactInterface
    {
        private readonly ContactDbContext  _context;

        public ContactService(ContactDbContext context)
        {
            _context = context;
        }

        public async Task<ContactDTO> CreateContact(ContactCreateDTO newContact)
        {
            throw new NotImplementedException();
        }

        public Task DeleteContact(int contactId)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<ContactDTO>> GetContacts()
        {
            var result = await _context.Contacts.ToListAsync();
            return result.Select(c => new ContactDTO
            {
                Id = c.Id,
                FirstName = c.FirstName,
                LastName = c.LastName,
                CreatedAt = c.CreatedAt
            });
        }

        public Task<IEnumerator<ContactDTO>> GetGroupContacts(int groupId)
        {
            throw new NotImplementedException();
        }
    }
}
