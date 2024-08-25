using API.StefaniniTest.Domain.Commands;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.StefaniniTest.Domain.Validators
{
    public class InsertProductCommandValidator : AbstractValidator<InsertProductCommand>
    {
        public InsertProductCommandValidator() 
        {
            RuleFor(x => x.NomeProduto)
                .NotEmpty().WithMessage("É necessário informar um nome para o produto!")
                .MaximumLength(20).WithMessage("Nome do produto deve possuir no máximo 20 caracteres!");

            RuleFor(x => x.Valor)
                .NotEmpty().WithMessage("É necessário informar um valor para o produto!")
                .ScalePrecision(2, 10).WithMessage("Valor deve possui no máximo 10 dígitos incluindo 2 casas decimais!");
        }
    }
}
