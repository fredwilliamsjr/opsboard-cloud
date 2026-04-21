using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OpsBoard.Api.Data;
using OpsBoard.Api.Entities;
using OpsBoard.Api.Services;

namespace OpsBoard.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ServicesController : ControllerBase
    {
        private readonly OpsBoard.Api.Services.IServiceManager _serviceManager;

        public ServicesController(OpsBoard.Api.Services.IServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var services = await _serviceManager.GetAllAsync();
            return Ok(services);
        }
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var service = await _serviceManager.GetByIdAsync(id);

            if (service == null)
                return NotFound();

            return Ok(service);
        }
        
        [HttpPost]
        public async Task<IActionResult> Create(OpsBoard.Api.DTOs.CreateServiceDto dto)
        {
            if (!ModelState.IsValid)
                return ValidationProblem(ModelState);

            var created = await _serviceManager.CreateAsync(dto);

            return CreatedAtAction(nameof(GetAll), new { id = created.Id }, created);
        }
        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(int id, OpsBoard.Api.DTOs.UpdateServiceDto dto)
        {
            if (!ModelState.IsValid)
                return ValidationProblem(ModelState);

            var updated = await _serviceManager.UpdateAsync(id, dto);

            if (!updated)
                return NotFound();

            return NoContent();
        }
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _serviceManager.DeleteAsync(id);

            if (!deleted)
                return NotFound();

            return NoContent();
        }
    }
}
