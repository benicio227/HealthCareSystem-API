using HealthCareSystem.Application.Commands.Patients;
using HealthCareSystem.Application.Queries.Patients;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace HealthCareSystem.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientsController : ControllerBase
    {
        private readonly IMediator _mediator;
        public PatientsController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost]
        public async Task<IActionResult> CreatePatient(InsertPatientCommand command)
        {
            var result = await _mediator.Send(command);

            if (!result.Success)
            {
                return BadRequest(result);
            }

            return CreatedAtAction(nameof(GetPatientById), new {id = result.Data!.Id}, result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllPatients()
        {
            var response = await _mediator.Send(new GetAllPatientsQuery());

            if (!response.Success)
            {
                return NotFound(response);
            }

            return Ok(response);
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetPatientById(Guid id)
        {
            var query = new GetPatientByIdQuery();
            query.Id = id;

            var response = await _mediator.Send(query);

            if (!response.Success)
            {
                return NotFound(response);
            }

            return Ok(response);
        }

        [HttpGet("cpf/{cpf}")]
        public async Task<IActionResult> GetPatientByCpf(string cpf)
        {
            var query = new GetPatientByCpfQuery();
            query.Cpf = cpf;

            var response = await _mediator.Send(query);

            if (!response.Success)
            {
                return NotFound(response);
            }

            return Ok(response);
        }

        [HttpGet("phone/{phone}")]
        public async Task<IActionResult> GetPatientByPhone(string phone)
        {
            var query = new GetPatientByPhoneQuery();
            query.Phone = phone;

            var response = await _mediator.Send(query);

            if (!response.Success)
            {
                return NotFound(response);
            }

            return Ok(response);
        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> UpdatePatient(Guid id, UpdatePatientCommand command)
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
        public async Task<IActionResult> DeletePatient(Guid id)
        {
            var command = new DeletePatientCommand();
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
