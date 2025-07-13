using HealthCareSystem.Application.Commands.Appointments;
using HealthCareSystem.Application.Queries.Appointments;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace HealthCareSystem.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentsController : ControllerBase
    {
        private readonly IMediator _mediator;
        public AppointmentsController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost]
        public async Task<IActionResult> CreateAppointment(InsertAppointmentCommand command)
        {
            var response = await _mediator.Send(command);

            if (!response.Success)
            {
                return BadRequest(response);
            }


            return CreatedAtAction(nameof(GetAppointmentById), new {id = response.Data!.Id}, response);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAppointments()
        {
            var query = new GetAllAppointmentQuery();

            var response = await _mediator.Send(query);

            return Ok(response);
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetAppointmentById(Guid id)
        {
            var query = new GetByIdAppointmentQuery();
            query.Id = id;

            var response = await _mediator.Send(query);

            if (!response.Success)
            {
                return NotFound(response);
            }

            return Ok(response);
        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> UpdateAppointment(Guid id, UpdateAppointmentCommand command)
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
        public async Task<IActionResult> DeleteAppointment(Guid id)
        {
            var command = new DeleteAppointmentCommand();
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
