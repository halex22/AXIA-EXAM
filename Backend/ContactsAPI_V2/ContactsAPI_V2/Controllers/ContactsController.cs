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
    public class ContactsController : ControllerBase
    {
        private readonly IContactService _service;

        public ContactsController(IContactService service)
        {
            _service = service;
        }

        // GET: api/Contacts
        [HttpGet]
        public async Task<IActionResult> GetContacts()
        {
            var res = await _service.GetAllContacts();
            return Ok(res); 
        }

        // GET: api/Contacts/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetContact([FromRoute]int id)
        {
            try
            {
                var res = await _service.GetContactById(id);
                return Ok(res);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }



        // POST: api/Contacts
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<IActionResult> PostContact([FromBody]ContactCreateDTO contact)
        {
            try
            {
                var res = await _service.CreateContact(contact);
                return CreatedAtAction("GetContact", new { id = res.Id }, res);
            }
            catch (Exception)
            {
                return BadRequest();
            }

        }

        // DELETE: api/Contacts/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteContact(int id)
        {
            try
            {
                await _service.DeleteContact(id);
                return NoContent();
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                // For unexpected errors
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }

        }


    }
}
