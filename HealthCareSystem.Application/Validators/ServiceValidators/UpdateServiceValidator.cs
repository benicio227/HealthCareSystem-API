using FluentValidation;
using HealthCareSystem.Application.Commands.Services;

namespace HealthCareSystem.Application.Validators.ServiceValidators
{
    public class UpdateServiceValidator : AbstractValidator<UpdateServiceCommand>
    {
        public UpdateServiceValidator()
        {
            RuleFor(s => s.Name)
                .NotEmpty().WithMessage("O nome do serviço é obrigatório.");

            RuleFor(s => s.Description)
                .NotEmpty().WithMessage("O nome da descrição é obrigatório");

            RuleFor(s => s.Price)
                .GreaterThan(0).WithMessage("O valor deve ser maior que zero.");

            RuleFor(s => s.DurationInMinutes)
                .Cascade(CascadeMode.Stop)
                .GreaterThan(0).WithMessage("A duração deve ser maior que zero minutos.")
                .LessThanOrEqualTo(480).WithMessage("A duração não pode exceder 8 horas.");
        }
    }
}
