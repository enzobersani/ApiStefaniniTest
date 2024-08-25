using API.StefaniniTest.Domain.Commands;
using Mapster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.StefaniniTest.Domain.Entities
{
    public class Pedido
    {
        public int Id { get; private set; }
        public string NomeCliente { get; private set; }
        public string EmailCliente { get; private set; }
        public DateTime DataCriacao { get; private set; } = DateTime.Now;
        public bool Pago { get; private set; }

        public ICollection<ItemPedido> ItensPedidos { get; set; } = new List<ItemPedido>();

        public static Pedido New(UpsertOrderCommand request)
        {
            var pedido = new Pedido();
            request.Adapt(pedido);
            return pedido;
        }

        public void ChangesSituation(bool pago)
        {
            Pago = pago;
        }
    }
}
