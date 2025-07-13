using HealthCareSystem.Application.Commands.Services;
using HealthCareSystem.Application.Queries.Services;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace HealthCareSystem.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServicesController : ControllerBase
    {
        private readonly IMediator _mediator;
        public ServicesController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost]
        public async Task<IActionResult> CreateService(InsertServiceCommand command)
        {
            var response = await _mediator.Send(command);

            return CreatedAtAction(nameof(GetServiceById), new {id = response.Data!.Id}, response);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllServices()
        {
            var query = new GetAllServicesQuery();
            var response = await _mediator.Send(query);
          
            return Ok(response);
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetServiceById(Guid id)
        {
            var query = new GetServiceByIdQuery();
            query.Id = id;

            var response = await _mediator.Send(query);

            if (!response.Success)
            {
                return NotFound(response);
            }

            return Ok(response);
        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> UpdateService(Guid id, UpdateServiceCommand command)
        {
            command.SetId(id);

            var response = await _mediator.Send(command);

            if (!response.Success)
            {
                return NotFound(response);
            }

            return NoContent();
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> DeleteService(Guid id)
        {
            var command = new DeleteServiceCommand();
            command.Id = id;

            var response = await _mediator.Send(command);

            if (!response.Success)
            {
                return NotFound(response);
            }

            return NoContent();
        }
    }
}
