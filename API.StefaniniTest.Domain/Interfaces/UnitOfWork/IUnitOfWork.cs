using API.StefaniniTest.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.StefaniniTest.Domain.Interfaces.UnitOfWork
{
    public interface IUnitOfWork
    {
        Task<bool> CommitAsync();
        IProductRepository ProductRepository { get; }
        IOrderRepository OrderRepository { get; }
    }
}
