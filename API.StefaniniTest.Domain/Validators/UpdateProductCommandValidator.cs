using API.StefaniniTest.Domain.Commands;
using FluentValidation;

namespace API.StefaniniTest.Domain.Validators
{
    public class UpdateProductCommandValidator : AbstractValidator<UpdateProductCommand>
    {
        public UpdateProductCommandValidator() 
        {
            RuleFor(x => x.Id)
                .NotEmpty().WithMessage("Id do produto é obrigatório!");

            RuleFor(x => x.NomeProduto)
                .NotEmpty().WithMessage("É necessário informar um nome para o produto!")
                .MaximumLength(20).WithMessage("Nome do produto deve ter no máximo 20 caracteres!");

            RuleFor(x => x.Valor)
                .NotEmpty().WithMessage("É necessário informar um valor para o produto!")
                .ScalePrecision(2, 10).WithMessage("Valor deve possui no máximo 10 dígitos incluindo 2 casas decimais!");
        }
    }
}
