using ContactsAPI_V2.Model;
using ContactsAPI_V2.Model.DTO;
using ContactsAPI_V2.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Runtime.InteropServices;

namespace ContactsAPI_V2.Services
{
    public class GroupSerice : IGroupService
    {
        private readonly ContactsDbContext _context;


        public GroupSerice(ContactsDbContext context)
        {
            _context = context;
        }

        public async Task AddContactToGroup(int ContactId, int groupId)
        {
            var contact = await _context.Contacts.FindAsync(ContactId);
            if (contact == null)
            {
                throw new KeyNotFoundException("Contact was not found");
            }

            Console.WriteLine($"Looking for group id {groupId}");
            var group = await _context.Groups.FindAsync(groupId);
            if (group == null)
            {
                throw new KeyNotFoundException("Group was not found");
            }

            var link = new GroupContact
            {
                GroupId = group.Id,
                ContactId = contact.Id,
            };

            _context.GroupContacts.Add(link);
            await _context.SaveChangesAsync();
        }

        public async Task<GroupDTO> CreateGroup(GroupCreateTDO group)
        {
            var newGroup = new Group
            {
                Name = group.Name
            };
            _context.Groups.Add(newGroup);
            await _context.SaveChangesAsync();

            return new GroupDTO
            {
                Name = newGroup.Name,
                Id = newGroup.Id
            };

        }

        public async Task<IEnumerable<GroupDTO>> GetAllGroups()
        {
            var result = await _context.Groups.ToListAsync();
            return result.Select(r => new GroupDTO
            {
                Name = r.Name,
                Id = r.Id
            });
        }

        public async Task<IEnumerable<ContactDTO>> GetGroupContacts(int groupId)
        {
            var groupWithContacts = await _context.Groups
                .Where(g => g.Id == groupId)
                .Include(g => g.GroupContacts)
                .ThenInclude(gc => gc.Contact)
                .FirstOrDefaultAsync();

            if (groupWithContacts == null)
            {
                throw new KeyNotFoundException("No Group with given Id was found");
            }
            
            var contacts = groupWithContacts.GroupContacts.Select(g => g.Contact).ToList();

            return contacts.Select(c => new ContactDTO
            {
                CreatedAt = c.CreatedAt,
                FirstName = c.FirstName,
                LastName = c.LastName,
                Id = c.Id
            });
        }
    }
}
