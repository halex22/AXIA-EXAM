using ContactsAPI_V2.Model;
using ContactsAPI_V2.Model.DTO;
using ContactsAPI_V2.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace ContactsAPI_V2.Services
{
    public class ContactService : IContactService
    {
        private readonly ContactsDbContext _context;

        public ContactService(ContactsDbContext context)
        {
            _context = context;
        }

        public async Task<ContactDTO> CreateContact(ContactCreateDTO contact)
        {
            var newContact = new Contact
            {
                FirstName = contact.FirstName,
                LastName = contact.LastName
            };

            _context.Contacts.Add(newContact);
            await _context.SaveChangesAsync();

            return ConvertToDTO(newContact);
        }

        public async Task DeleteContact(int id)
        {
            var contact = await FetchContactIfExists(id);

            _context.Contacts.Remove(contact);
            await _context.SaveChangesAsync();

        }

        public async Task<IEnumerable<ContactDTO>> GetAllContacts()
        {
            var result = await _context.Contacts.ToListAsync();
            return result.Select( r => ConvertToDTO(r)).ToList(); 
            
        }

        public async Task<ContactDTO> GetContactById(int id)
        {
            var contact = await FetchContactIfExists(id);
            return ConvertToDTO(contact);
        }

        private ContactDTO ConvertToDTO(Contact contact)
        {
            return new ContactDTO
            {
                Id = contact.Id,
                FirstName = contact.FirstName,
                LastName = contact.LastName,
                CreatedAt = contact.CreatedAt,
            };
        }

        private async Task<Contact> FetchContactIfExists(int id)
        {
            var contact = await _context.Contacts.FindAsync(id);

            if (contact == null)
            {
                throw new KeyNotFoundException($"No Contact with id {id} was found");
            }
            return contact;
        }
    }
}
