using FluentValidation;
using HealthCareSystem.Application.Commands.Doctors;
using System.Text.RegularExpressions;

namespace HealthCareSystem.Application.Validators.DoctorValidators
{
    public class UpdateDoctorValidator : AbstractValidator<UpdateDoctorCommand>
    {
        public UpdateDoctorValidator()
        {
            RuleFor(d => d.FirstName)
                .NotEmpty().WithMessage("O nome é obrigatório.");

            RuleFor(d => d.LastName)
                .NotEmpty().WithMessage("O sobrenome é obrigatório.");

            RuleFor(d => d.Email)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("O email é obrigatório.")
                .EmailAddress().WithMessage("O email é inválido.");

            RuleFor(d => d.Phone)
                .Must(phone => Regex.IsMatch(phone, @"^\d{10,11}$"))
                .WithMessage("Telefone inválido. Ex: 11987654321 ou 1123456789");

            RuleFor(d => d.Address)
                .NotEmpty().WithMessage("O endereço é obrigatório.");

            RuleFor(d => d.Specialty)
                .NotEmpty().WithMessage("O tipo de especialidade é obrigatório.")
                .IsInEnum();
        }
    }
}
