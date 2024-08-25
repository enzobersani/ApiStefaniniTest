using API.StefaniniTest.Domain.Commands;
using API.StefaniniTest.Domain.Models;
using Mapster;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.StefaniniTest.Domain.Entities
{
    public class ItemPedido
    {
        public int Id { get; private set; }
        public int IdPedido { get; private set; }
        public int IdProduto { get; private set; }
        public int Quantidade { get; private set; }

        public Pedido Pedidos { get; set; }
        public Produto Produtos { get; set; }

        public static ItemPedido New(ItemOrderModel request)
        {
            var itemPedido = new ItemPedido();
            request.Adapt(itemPedido);
            return itemPedido;
        }
    }
}
