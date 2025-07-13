using HealthCareSystem.Application.Commands.Doctors;
using HealthCareSystem.Application.Queries.Doctors;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace HealthCareSystem.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorsController : ControllerBase
    {
        private readonly IMediator _mediator;
        public DoctorsController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost]
        public async Task<IActionResult> CreateDoctor(InsertDoctorCommand command)
        {
            var response = await _mediator.Send(command);

            if (!response.Success)
            {
                return BadRequest(response);
            }

            return CreatedAtAction(nameof(GetDoctorById), new {id = response.Data!.Id}, response);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllDoctors()
        {
            var query = new GetAllDoctorQuery();

            var response = await _mediator.Send(query);

            return Ok(response);
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetDoctorById(Guid id)
        {
            var query = new GetByIdDoctorQuery();
            query.Id = id;

            var response = await _mediator.Send(query);

            if (!response.Success)
            {
                return NotFound(response);
            }

            return Ok(response);
        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> UpdateDoctor(Guid id, UpdateDoctorCommand command)
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
        public async Task<IActionResult> DeleteDoctor(Guid id)
        {
            var command = new DeleteDoctorCommand();
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
