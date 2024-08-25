using API.StefaniniTest.Domain.Models;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.StefaniniTest.Domain.Validators
{
    public class ItemOrderModelValidator : AbstractValidator<ItemOrderModel>
    {
        public ItemOrderModelValidator() 
        {
            RuleFor(x => x.IdProduto)
                .NotEmpty().WithMessage("O ID do produto deve ser maior que zero!");

            RuleFor(x => x.Quantidade)
                .GreaterThan(0).WithMessage("A quantidade deve ser maior que zero!");
        }
    }
}
