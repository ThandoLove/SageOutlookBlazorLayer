using Microsoft.AspNetCore.Mvc;
using SageX3OutlookApplication.DTOs;
using SageX3OutlookApplication.Interfaces;



namespace SageX3OutlookAPI.Controllers;

   
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class EmailController : ControllerBase
    {
        private readonly IEmailService _emailService;

        public EmailController(IEmailService emailService)
        {
            _emailService = emailService ?? throw new ArgumentNullException(nameof(emailService));
        }

        // -------------------------------------------------------
        // GET: api/email
        // -------------------------------------------------------
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<EmailDto>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAll()
        {
            var emails = await _emailService.GetAllEmailsAsync();
            return Ok(emails);
        }

        // -------------------------------------------------------
        // POST: api/email
        // Creates an email record in system
        // -------------------------------------------------------
        [HttpPost]
        [ProducesResponseType(typeof(EmailDto), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Create([FromBody] EmailDto request)
        {
            if (request == null)
                return BadRequest("Email payload is required.");

            var created = await _emailService.CreateEmailRecordAsync(request);

            return CreatedAtAction(
                nameof(GetAll),
                new { id = created.Id },
                created);
        }
    }
