using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace API.StefaniniTest.Domain.Models
{
    public class ItemOrderModel
    {
        public int IdProduto { get; set; }
        public int Quantidade { get; set; }
    }
}
