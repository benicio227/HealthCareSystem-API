using FluentValidation;
using HealthCareSystem.Application.Commands.Patients;
using System.Text.RegularExpressions;

namespace HealthCareSystem.Application.Validators.PatientValidators
{
    public class InsertPatientValidator : AbstractValidator<InsertPatientCommand>
    {
        public InsertPatientValidator()
        {
            RuleFor(p => p.FirstName)
                .NotEmpty().WithMessage("O nome é obrigatório.");

            RuleFor(p => p.LastName)
                .NotEmpty().WithMessage("O sobrenome é obrigatório.");

            RuleFor(p => p.Email)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("O email é obrigatório.")
                .EmailAddress().WithMessage("O email é inválido.");

            RuleFor(p => p.DateOfBirth)
                .NotEmpty().WithMessage("A data de nascimento é obrigatória.")
                .LessThan(DateTime.Now).WithMessage("A data de nascimento não pode ser futura.");

            RuleFor(p => p.Phone)
    .           NotEmpty().WithMessage("O telefone é obrigatório.")
               .Matches(@"^\+\d{10,15}$").WithMessage("Telefone inválido. Use o formato internacional, ex: +5582987514902");


            RuleFor(p => p.Cpf)
                .NotEmpty().WithMessage("O CPF é obrigatório.");

            RuleFor(p => p.BloodType)
                .NotEmpty().WithMessage("O tipo sanguíneo é obrigatório.")
                .IsInEnum();

            RuleFor(p => p.Height)
                .GreaterThan(0).WithMessage("A altura deve ser maior que zero.");

            RuleFor(P => P.Weight)
                .GreaterThan(0).WithMessage("O peso deve ser maior que zero.");

            RuleFor(p => p.Address)
                .NotEmpty().WithMessage("O endereço é obrigatório");
        }
    }
}
