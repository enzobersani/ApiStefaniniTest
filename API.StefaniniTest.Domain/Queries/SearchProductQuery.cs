using API.StefaniniTest.Domain.Models.Response;
using MediatR;

namespace API.StefaniniTest.Domain.Queries
{
    public class SearchProductQuery : IRequest<List<ProductResponseModel>>
    {
        public string NomeProduto { get; set; }
    }
}
