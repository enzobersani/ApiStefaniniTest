using API.StefaniniTest.Domain.Commands;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.StefaniniTest.Domain.Validators
{
    public class DeleteOrderItemsCommandValidator : AbstractValidator<DeleteOrderItemsCommand>
    {
        public DeleteOrderItemsCommandValidator() 
        {
            RuleFor(x => x.IdPedido)
                .NotEmpty().WithMessage("Id do pedido é obrigatório!");

            RuleFor(x => x.ListaIdItens)
                .NotEmpty().WithMessage("É necessário informar algum item!");
        }
    }
}
