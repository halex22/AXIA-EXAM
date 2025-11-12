using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ContactsAPI_V2.Model;
using ContactsAPI_V2.Services.Interfaces;
using ContactsAPI_V2.Model.DTO;

namespace ContactsAPI_V2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GroupsController : ControllerBase
    {
        private readonly IGroupService _service;

        public GroupsController(IGroupService service)
        {
            _service = service;
        }

        // GET: api/Groups
        [HttpGet]
        public async Task<IActionResult> GetGroups()
        {
            var result = await _service.GetAllGroups();
            return Ok(result);
        }

        // GET: api/Groups/5
        [HttpGet("contacts-by-group/{id}")]
        public async Task<IActionResult> GetGroup(int id)
        {
            var result = await _service.GetGroupContacts(id);
            return Ok(result);
        }

        [HttpPost("add-to-group/{groupId}/{contactId}")]
        public async Task<IActionResult> AddContactToGroup(int groupId, int contactId)
        {
            await _service.AddContactToGroup(contactId, groupId);
            return NoContent();
        }


        // POST: api/Groups
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<IActionResult> PostGroup([FromBody]GroupCreateTDO @group)
        {
            try
            {
                var result = await _service.CreateGroup(@group);
                return Created(String.Empty, result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Something went wrong please try again");
            }
        }

    }
}
