using API.StefaniniTest.Domain.Entities;
using API.StefaniniTest.Domain.Interfaces.UnitOfWork;
using API.StefaniniTest.Domain.Models.Response;
using API.StefaniniTest.Domain.Notifications;
using API.StefaniniTest.Domain.Queries;
using MediatR;

namespace API.StefaniniTest.Domain.Handlers.QueryHandler
{
    public class OrderQueryHandler : IRequestHandler<SearchOrdersQuery, List<SearchOrderResponseModel>>
    {
        private readonly INotificationService _notifications;
        private readonly IUnitOfWork _unitOfWork;

        public OrderQueryHandler(INotificationService notifications, IUnitOfWork unitOfWork)
        {
            _notifications = notifications;
            _unitOfWork = unitOfWork;
        }

        public async Task<List<SearchOrderResponseModel>> Handle(SearchOrdersQuery request, CancellationToken cancellationToken)
        {
            var orderResponseList = new List<SearchOrderResponseModel>();
            foreach (var orderId in request.Id)
            {
                var order = await _unitOfWork.OrderRepository.GetById(orderId);
                if (order is null)
                {
                    _notifications.AddNotification("Handle", $"Pedido {orderId} não encontrado!");
                    continue;
                }

                var orderResponse = new SearchOrderResponseModel
                {
                    Id = order.Id,
                    NomeCliente = order.NomeCliente,
                    EmailCliente = order.EmailCliente,
                    Pago = order.Pago,
                    ValorTotal = order.ItensPedidos.Sum(x => x.Produtos.Valor * x.Quantidade),
                    ItensPedido = order.ItensPedidos.Select(item => new ItemsOrderResponseModel
                    {
                        Id = item.Id,
                        IdProduto = item.IdProduto,
                        NomeProduto = item.Produtos.NomeProduto,
                        ValorUnitario = item.Produtos.Valor,
                        Quantidade = item.Quantidade
                    }).ToList()
                };

                orderResponseList.Add(orderResponse);
            }

            return orderResponseList;
        }
    }
}
