using ApiProjeto.Domain.Entities;
using FluentValidation;

namespace ApiProjeto.Service.Validators
{
    public class ValidatorPessoa : AbstractValidator<Pessoa>
    {
        public ValidatorPessoa()
        {
            RuleFor(c => c.Nome_Fantasia)
                .NotEmpty().WithMessage("Nome obrigatório.")
                .NotNull().WithMessage("Nome obrigatório.");

            RuleFor(c => c.Cnpj_Cpf)
                .NotEmpty().WithMessage("CPF/CNPJ obrigatório.")
                .NotNull().WithMessage("CPF/CNPJ obrigatório.");
        }
    }
}
