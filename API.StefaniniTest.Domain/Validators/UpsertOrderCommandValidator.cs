using API.StefaniniTest.Domain.Commands;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.StefaniniTest.Domain.Validators
{
    public class UpsertOrderCommandValidator : AbstractValidator<UpsertOrderCommand>
    {
        public UpsertOrderCommandValidator() 
        {
            RuleFor(x => x.NomeCliente)
                .NotEmpty().WithMessage("É necessário informar um nome para o cliente!")
                .MaximumLength(60).WithMessage("Nome do cliente deve possuir no máximo 60 caracteres!");

            RuleFor(x => x.EmailCliente)
                .NotEmpty().WithMessage("É necessário informar um email para o cliente!")
                .MaximumLength(60).WithMessage("Email do cliente deve possuir no máximo 60 caracteres!");

            RuleForEach(x => x.ItensPedido)
                .SetValidator(new ItemOrderModelValidator());
        }
    }
}
