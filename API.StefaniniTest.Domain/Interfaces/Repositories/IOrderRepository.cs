using API.StefaniniTest.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.StefaniniTest.Domain.Interfaces.Repositories
{
    public interface IOrderRepository
    {
        Task Add(Pedido order);
        Task<Pedido> GetById(int id);
        Task Update(Pedido order);
        Task Delete(Pedido order);
    }
}
