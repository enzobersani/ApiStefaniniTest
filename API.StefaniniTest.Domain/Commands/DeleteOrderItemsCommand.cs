using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace API.StefaniniTest.Domain.Commands
{
    public class DeleteOrderItemsCommand : IRequest<Unit>
    {
        [JsonIgnore]
        public int IdPedido { get; set; }
        public List<int> ListaIdItens { get; set; }

        public DeleteOrderItemsCommand(int idPedido) 
        {
            IdPedido = idPedido;
        }
    }
}
