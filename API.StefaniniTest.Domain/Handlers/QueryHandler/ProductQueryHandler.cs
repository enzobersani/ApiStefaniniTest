using API.StefaniniTest.Domain.Entities;
using API.StefaniniTest.Domain.Interfaces.UnitOfWork;
using API.StefaniniTest.Domain.Models.Response;
using API.StefaniniTest.Domain.Notifications;
using API.StefaniniTest.Domain.Queries;
using MediatR;

namespace API.StefaniniTest.Domain.Handlers.QueryHandler
{
    public class ProductQueryHandler : IRequestHandler<SearchProductQuery, List<ProductResponseModel>>
    {
        private readonly INotificationService _notifications;
        private readonly IUnitOfWork _unitOfWork;

        public ProductQueryHandler(INotificationService notifications, IUnitOfWork unitOfWork)
        {
            _notifications = notifications;
            _unitOfWork = unitOfWork;
        }

        public async Task<List<ProductResponseModel>> Handle(SearchProductQuery request, CancellationToken cancellationToken)
        {
            List<Produto> products;
            var response = new List<ProductResponseModel>();
            if(request.NomeProduto is not null)
                products = await _unitOfWork.ProductRepository.GetByNameContains(request.NomeProduto);
            else
                products = await _unitOfWork.ProductRepository.GetAll();

            if (products == null || products.Count == 0)
                return new List<ProductResponseModel>();

            foreach (var product in products)
            {
                response.Add(new ProductResponseModel
                {
                    Id = product.Id,
                    NomeProduto = product.NomeProduto,
                    Valor = product.Valor
                });
            }
            return response;
        }
    }
}
