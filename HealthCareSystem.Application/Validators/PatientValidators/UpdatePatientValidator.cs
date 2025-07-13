using FluentValidation;
using HealthCareSystem.Application.Commands.Patients;
using System.Text.RegularExpressions;

namespace HealthCareSystem.Application.Validators.PatientValidators
{
    public class UpdatePatientValidator : AbstractValidator<UpdatePatientCommand>
    {
        public UpdatePatientValidator()
        {
            RuleFor(p => p.FirstName)
                .NotEmpty().WithMessage("O nome é obrigatório.");

            RuleFor(p => p.LastName)
                .NotEmpty().WithMessage("O sobrenome é obrigatório.");

            RuleFor(p => p.Email)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("O email é obrigatório.")
                .EmailAddress().WithMessage("O email é inválido.");

            RuleFor(p => p.Phone)
                .Must(phone => Regex.IsMatch(phone, @"^\d{10,11}$"))
                .WithMessage("Telefone inválido. Ex: 11987654321 ou 1123456789");

            RuleFor(p => p.Height)
                .GreaterThan(0).WithMessage("A altura é obrigatória.");

            RuleFor(P => P.Weight)
                .GreaterThan(0).WithMessage("O peso é obrigatório.");

            RuleFor(p => p.Address)
                .NotEmpty().WithMessage("O endereço é obrigatório");

        }
    }
}
