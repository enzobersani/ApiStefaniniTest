using API.StefaniniTest.Domain.Commands;
using Mapster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.StefaniniTest.Domain.Entities
{
    public class Produto
    {
        public int Id { get; private set; }
        public string NomeProduto { get; private set; }
        public decimal Valor { get; private set; }

        public ICollection<ItemPedido> ItensPedidos { get; set; } = new List<ItemPedido>();

        public static Produto New(InsertProductCommand request)
        {
            var produto = new Produto();
            request.Adapt(produto);
            return produto;
        }

        public void Update(UpdateProductCommand request)
        {
            if(request.NomeProduto != null)
                NomeProduto = request.NomeProduto;

            if(request.Valor.HasValue)
                Valor = (decimal)request.Valor;
        }
    }
}
