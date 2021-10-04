using Domain.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Validators
{
    public class ClienteValidator : AbstractValidator<Cliente>
    {

        public ClienteValidator() 
        {
            RuleFor(c => c.Nome)
                .NotEmpty().WithMessage("Informe o nome!")
                .NotNull().WithMessage("Informe o nome!");

            RuleFor(c => c.Email)
                .NotEmpty().WithMessage("Informe o email!")
                .NotNull().WithMessage("Informe o email!");

            RuleFor(c => c.Cpf)
                .NotEmpty().WithMessage("Informe o cpf!")
                .NotNull().WithMessage("Informe o cpf!");
        }


    }
}
