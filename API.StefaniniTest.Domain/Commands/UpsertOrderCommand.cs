using API.StefaniniTest.Domain.Models;
using API.StefaniniTest.Domain.Models.Response;
using MediatR;

namespace API.StefaniniTest.Domain.Commands
{
    public class UpsertOrderCommand : IRequest<BaseResponseModel>
    {
        public int Id { get; set; }
        public string NomeCliente { get; set; }
        public string EmailCliente { get; set; }
        public bool Pago { get; set; }
        public List<ItemOrderModel> ItensPedido { get; set; }
    }
}
