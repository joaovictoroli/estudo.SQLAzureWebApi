using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApiSqlAzure.Data;
using WebApiSqlAzure.Model;
using WebApiSqlAzure.Repository;

namespace WebApiSqlAzure.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactsController : ControllerBase
    {

        private readonly IContactRepository contactRepository;

        public ContactsController(IContactRepository contactRepository)
        {
            this.contactRepository = contactRepository;
        }

        // GET: api/Contacts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Contact>>> GetContactsAsync()
        {
            return Ok(await contactRepository.GetAllAsync());
        }

        // GET: api/Contacts/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Contact>> GetContactAsync(int id)
        {
            var contact = await contactRepository.GetAsync(id);

            if (contact == null)
            {
                return NotFound();
            }

            return Ok(contact);
        }

        // PUT: api/Contacts/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut]
        [Route("{id:int}")]
        public async Task<IActionResult> PutContactAsync([FromRoute] int id, Contact updatedContactRequest)
        {
            var contact = await contactRepository.UpdateAsync(id, updatedContactRequest);

            if (contact == null)
            {
                return NotFound();
            }


            return Ok(updatedContactRequest);
        }

        // POST: api/Contacts
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Contact>> PostContactAsync(Contact contact)
        {
            await contactRepository.AddAsync(contact);

            return CreatedAtAction("GetContact", new { id = contact.Id }, contact);
        }

        // DELETE: api/Contacts/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteContact(int id)
        {
            var contact = await contactRepository.DeleteAsync(id);
            if (contact == null)
            {
                return NotFound();
            }                     

            return Ok(contact);
        }
    }
}
