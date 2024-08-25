using API.StefaniniTest.Domain.Commands;
using API.StefaniniTest.Domain.Entities;
using API.StefaniniTest.Domain.Interfaces.UnitOfWork;
using API.StefaniniTest.Domain.Models.Response;
using API.StefaniniTest.Domain.Notifications;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.StefaniniTest.Domain.Handlers.CommandHandler
{
    public class OrderCommandHandler : IRequestHandler<UpsertOrderCommand, BaseResponseModel>,
                                       IRequestHandler<DeleteOrderCommand, Unit>,
                                       IRequestHandler<DeleteOrderItemsCommand, Unit>,
                                       IRequestHandler<ChangesSituationOrderCommand, ChangesSituationOrderResponseModel>
    {
        private readonly INotificationService _notifications;
        private readonly IUnitOfWork _unitOfWork;

        public OrderCommandHandler(INotificationService notifications, IUnitOfWork unitOfWork)
        {
            _notifications = notifications;
            _unitOfWork = unitOfWork;
        }

        public async Task<BaseResponseModel> Handle(UpsertOrderCommand request, CancellationToken cancellationToken)
        {
            Pedido order;

            if (request.Id > 0)
            {
                order = await _unitOfWork.OrderRepository.GetById(request.Id);
                if (order is null)
                {
                    _notifications.AddNotification("Handle", "Pedido não encontrado.");
                    return new BaseResponseModel();
                }
            }
            else
            {
                order = Pedido.New(request);
                await _unitOfWork.OrderRepository.Add(order);
            }

            foreach (var item in request.ItensPedido)
            {
                var product = await _unitOfWork.ProductRepository.GetById(item.IdProduto);
                if(product is null)
                {
                    _notifications.AddNotification("Handle", $"Produto {item.IdProduto} não cadastrado!");
                    return new BaseResponseModel();
                }

                var itemOrder = ItemPedido.New(item);

                order.ItensPedidos.Add(itemOrder);
            }

            if(request.Id > 0) await _unitOfWork.OrderRepository.Update(order);
            await _unitOfWork.CommitAsync();

            return new BaseResponseModel { Id = order.Id };
        }

        public async Task<Unit> Handle(DeleteOrderCommand request, CancellationToken cancellationToken)
        {
            var order = await _unitOfWork.OrderRepository.GetById(request.Id);
            if(order is null)
            {
                _notifications.AddNotification("Handle", "Pedido informado não existe!");
                return Unit.Value;
            }

            if(order.ItensPedidos.Any())
            {
                _notifications.AddNotification("Handle", "Pedido informado possui itens, não é possível excluir!");
                return Unit.Value;
            }

            await _unitOfWork.OrderRepository.Delete(order);
            await _unitOfWork.CommitAsync();
            return Unit.Value;
        }

        public async Task<Unit> Handle(DeleteOrderItemsCommand request, CancellationToken cancellationToken)
        {
            var order = await _unitOfWork.OrderRepository.GetById(request.IdPedido);
            if(order is null)
            {
                _notifications.AddNotification("Handle", "Pedido informado não existe!");
                return Unit.Value;
            }

            foreach(var itemId in request.ListaIdItens)
            {
                var item = order.ItensPedidos.FirstOrDefault(i => i.Id == itemId);
                if (item is not null)
                    order.ItensPedidos.Remove(item);
                else
                    _notifications.AddNotification("Handle", $"Item {itemId} não encontrado no pedido {request.IdPedido}");
            }

            if(_notifications.HasNotifications())
                return Unit.Value;

            await _unitOfWork.OrderRepository.Update(order);
            await _unitOfWork.CommitAsync();

            return Unit.Value;
        }

        public async Task<ChangesSituationOrderResponseModel> Handle(ChangesSituationOrderCommand request, CancellationToken cancellationToken)
        {
            var order = await _unitOfWork.OrderRepository.GetById(request.Id);
            if(order is null)
            {
                _notifications.AddNotification("Handle", "Pedido informado não encontrado!");
                return new ChangesSituationOrderResponseModel();
            }

            order.ChangesSituation(request.Pago);
            await _unitOfWork.OrderRepository.Update(order);
            await _unitOfWork.CommitAsync();

            return new ChangesSituationOrderResponseModel 
            {
                Id = order.Id,
                Pago = order.Pago,
            };
        }
    }
}
