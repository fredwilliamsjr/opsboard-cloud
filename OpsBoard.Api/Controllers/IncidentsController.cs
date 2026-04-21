using Microsoft.AspNetCore.Mvc;
using OpsBoard.Api.DTOs;
using OpsBoard.Api.Services;

namespace OpsBoard.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class IncidentsController : ControllerBase
    {
        private readonly IIncidentManager _incidentManager;

        public IncidentsController(IIncidentManager incidentManager)
        {
            _incidentManager = incidentManager;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var incidents = await _incidentManager.GetAllAsync();
            return Ok(incidents);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var incident = await _incidentManager.GetByIdAsync(id);

            if (incident == null)
                return NotFound();

            return Ok(incident);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateIncidentDto dto)
        {
            var incident = await _incidentManager.CreateAsync(dto);

            if (incident == null)
                return BadRequest("ServiceItemId is invalid.");

            return CreatedAtAction(nameof(GetById), new { id = incident.Id }, incident);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, UpdateIncidentDto dto)
        {
            var updated = await _incidentManager.UpdateAsync(id, dto);

            if (!updated)
                return BadRequest("Incident not found or ServiceItemId is invalid.");

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _incidentManager.DeleteAsync(id);

            if (!deleted)
                return NotFound();

            return NoContent();
        }
    }
}