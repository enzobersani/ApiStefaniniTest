using API.StefaniniTest.Domain.Models.Response;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.StefaniniTest.Domain.Commands
{
    public class InsertProductCommand : IRequest<BaseResponseModel>
    {
        public string NomeProduto { get; set; }
        public decimal Valor { get; set; }
    }
}
