using API.StefaniniTest.Domain.Queries;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.StefaniniTest.Domain.Validators
{
    public class SearchOrdersQueryValidator : AbstractValidator<SearchOrdersQuery>
    {
        public SearchOrdersQueryValidator() 
        {
            RuleFor(x => x.Id)
                .NotEmpty().WithMessage("É necessário informar um Id de pedido");
        }
    }
}
