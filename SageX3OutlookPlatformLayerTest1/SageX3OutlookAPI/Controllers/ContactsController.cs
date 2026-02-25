using Microsoft.AspNetCore.Mvc;
using SageX3OutlookApplication.Interfaces;
using SageX3OutlookApplication.Requests.ContactsR;

namespace SageX3OutlookAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ContactsController : ControllerBase
    {
        private readonly IContactService _contactService;

        public ContactsController(IContactService contactService)
        {
            _contactService = contactService;
        }

        // ----------------------------------------------------
        // GET: api/contacts
        // ----------------------------------------------------
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAll()
        {
            var contacts = await _contactService.GetAllAsync();
            return Ok(contacts);
        }

        // ----------------------------------------------------
        // POST: api/contacts
        // ----------------------------------------------------
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Create([FromBody] CreateContactRequest request)
        {
            if (request == null)
                return BadRequest("Invalid request body.");

            var result = await _contactService.CreateAsync(request);

            return CreatedAtAction(
                nameof(GetAll),
                new { id = result.Id },
                result);
        }

        // ----------------------------------------------------
        // PUT: api/contacts/{id}
        // ----------------------------------------------------
        [HttpPut("{id:guid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Update(Guid id, [FromBody] UpdateContactRequest request)
        {
            if (id != request.Id)
                return BadRequest("Route ID and request ID do not match.");

            try
            {
                var updated = await _contactService.UpdateAsync(request);
                return Ok(updated);
            }
            catch (InvalidOperationException)
            {
                return NotFound($"Contact with ID {id} not found.");
            }
        }
    }
}