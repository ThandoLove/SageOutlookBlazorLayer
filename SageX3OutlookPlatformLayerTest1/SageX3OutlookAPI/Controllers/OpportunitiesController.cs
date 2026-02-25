using Microsoft.AspNetCore.Mvc;
using SageX3OutlookApplication.DTOs;
using SageX3OutlookApplication.Interfaces;
using SageX3OutlookApplication.Requests.OpportunitiesR;

namespace SageX3OutlookAPI.Controllers


{
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class OpportunitiesController : ControllerBase
    {
        private readonly IOpportunityService _opportunityService;

        public OpportunitiesController(IOpportunityService opportunityService)
        {
            _opportunityService = opportunityService
                ?? throw new ArgumentNullException(nameof(opportunityService));
        }

        // ---------------------------------------------------------
        // GET: api/opportunities
        // ---------------------------------------------------------
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<OpportunityDto>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAll()
        {
            var opportunities = await _opportunityService.GetAllAsync();
            return Ok(opportunities);
        }

        // ---------------------------------------------------------
        // POST: api/opportunities
        // ---------------------------------------------------------
        [HttpPost]
        [ProducesResponseType(typeof(OpportunityDto), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Create([FromBody] CreateOpportunityRequest request)
        {
            if (request == null)
                return BadRequest("Invalid request body.");

            var created = await _opportunityService.CreateAsync(request);

            return CreatedAtAction(
                nameof(GetAll),
                new { id = created.Id },
                created);
        }

        // ---------------------------------------------------------
        // PUT: api/opportunities/{id}
        // ---------------------------------------------------------
        [HttpPut("{id:guid}")]
        [ProducesResponseType(typeof(OpportunityDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Update(Guid id, [FromBody] UpdateOpportunityRequest request)
        {
            if (request == null)
                return BadRequest("Invalid request body.");

            if (id != request.Id)
                return BadRequest("Route ID and request ID do not match.");

            try
            {
                var updated = await _opportunityService.UpdateAsync(request);
                return Ok(updated);
            }
            catch (InvalidOperationException)
            {
                return NotFound($"Opportunity with ID {id} not found.");
            }
        }
    }
}