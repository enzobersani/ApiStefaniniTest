using API.StefaniniTest.Domain.Commands;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.StefaniniTest.Domain.Validators
{
    public class ChangesSituationOrderCommandValidator : AbstractValidator<ChangesSituationOrderCommand>
    {
        public ChangesSituationOrderCommandValidator() 
        {
            RuleFor(x => x.Id)
                .NotEmpty().WithMessage("É obrigatório informar o Id do pedido!");

            RuleFor(x => x.Pago)
                .NotEmpty().WithMessage("É obrigatório informar uma situação para o pedido!");
        }
    }
}
