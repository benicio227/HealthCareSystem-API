using FluentValidation;
using HealthCareSystem.Application.Commands.Doctors;
using System.Text.RegularExpressions;

namespace HealthCareSystem.Application.Validators.DoctorValidators
{
    public class InsertDoctorValidator : AbstractValidator<InsertDoctorCommand>
    {
        public InsertDoctorValidator()
        {
            RuleFor(d => d.FirstName)
                .NotEmpty().WithMessage("O nome é obrigatório.");

            RuleFor(d => d.LastName)
                .NotEmpty().WithMessage("O sobrenome é obrigatório.");

            RuleFor(d => d.Email)
                .NotEmpty().WithMessage("O email é obrigatório.")
                .EmailAddress().WithMessage("O email é inválido.");

            RuleFor(d => d.DateOfBirth)
                .NotEmpty().WithMessage("A data de nascimento é obrigatória.")
                .LessThan(DateTime.Now).WithMessage("A data de nascimento não pode ser futura.");

            RuleFor(d => d.Phone)
                .Must(phone => Regex.IsMatch(phone, @"^\d{10,11}$"))
                .WithMessage("Telefone inválido. Ex: 11987654321 ou 1123456789");

            RuleFor(d => d.Cpf)
                .NotEmpty().WithMessage("O CPF é obrigatório.");

            RuleFor(d => d.BloodType)
                .NotEmpty().WithMessage("O tipo sanguíneo é obrigatório.")
                .IsInEnum();

            RuleFor(d => d.Address)
                .NotEmpty().WithMessage("O endereço é obrigatório.");

            RuleFor(d => d.Specialty)
                .NotEmpty().WithMessage("O tipo de especialidade é obrigatório.")
                .IsInEnum();

            RuleFor(d => d.Crm)
                .NotEmpty().WithMessage("O CRM é obrigatório.");
        }
    }
}
