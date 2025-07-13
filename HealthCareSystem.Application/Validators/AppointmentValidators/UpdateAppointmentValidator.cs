using FluentValidation;
using HealthCareSystem.Application.Commands.Appointments;

namespace HealthCareSystem.Application.Validators.AppointmentValidators
{
    public class UpdateAppointmentValidator : AbstractValidator<UpdateAppointmentCommand>
    {
        public UpdateAppointmentValidator()
        {
            RuleFor(a => a.Insurance)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("O plano de saúde é obrigatório.")
                .MaximumLength(100).WithMessage("O nome do plano não pode ultrapassar 100 caracteres.");

            RuleFor(a => a.StartTime)
                .GreaterThan(DateTime.Now).WithMessage("A data/hora de início deve ser futura.");

            RuleFor(x => x.EndTime)
               .GreaterThan(x => x.StartTime).WithMessage("A data/hora de término deve ser após o início.");

            RuleFor(x => x.Type)
                .IsInEnum().WithMessage("Tipo de agendamento inválido.");
        }
    }
}
