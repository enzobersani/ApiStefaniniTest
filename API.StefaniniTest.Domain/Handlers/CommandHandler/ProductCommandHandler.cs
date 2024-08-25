using API.StefaniniTest.Domain.Commands;
using API.StefaniniTest.Domain.Entities;
using API.StefaniniTest.Domain.Interfaces.UnitOfWork;
using API.StefaniniTest.Domain.Models.Response;
using API.StefaniniTest.Domain.Notifications;
using MediatR;

namespace API.StefaniniTest.Domain.Handlers.CommandHandler
{
    public class ProductCommandHandler : IRequestHandler<InsertProductCommand, BaseResponseModel>,
                                         IRequestHandler<UpdateProductCommand, ProductResponseModel>,
                                         IRequestHandler<DeleteProductCommand, Unit>
    {
        private readonly INotificationService _notifications;
        private readonly IUnitOfWork _unitOfWork;

        public ProductCommandHandler(INotificationService notifications, IUnitOfWork unitOfWork)
        {
            _notifications = notifications;
            _unitOfWork = unitOfWork;
        }

        public async Task<BaseResponseModel> Handle(InsertProductCommand request, CancellationToken cancellationToken)
        {
            var produto = Produto.New(request);

            await _unitOfWork.ProductRepository.Add(produto);
            await _unitOfWork.CommitAsync();
            return new BaseResponseModel
            {
                Id = produto.Id,
            };
        }

        public async Task<ProductResponseModel> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            var produto = await _unitOfWork.ProductRepository.GetById(request.Id);
            if (produto is null)
            {
                _notifications.AddNotification("Handle", "Produto informado não cadastrado!");
                return new ProductResponseModel();
            }

            produto.Update(request);
            _unitOfWork.ProductRepository.Update(produto);
            await _unitOfWork.CommitAsync();

            return new ProductResponseModel
            {
                Id = produto.Id,
                NomeProduto = produto.NomeProduto,
                Valor = produto.Valor
            };
        }

        public async Task<Unit> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            var produto = await _unitOfWork.ProductRepository.GetById(request.Id);
            if (produto is null)
            {
                _notifications.AddNotification("Handle", "Produto informado não cadastrado!");
                return Unit.Value;
            }

            await _unitOfWork.ProductRepository.Delete(produto);
            await _unitOfWork.CommitAsync();
            return Unit.Value;
        }
    }
}
