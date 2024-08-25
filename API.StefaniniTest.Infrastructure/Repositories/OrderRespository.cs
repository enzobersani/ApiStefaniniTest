using API.StefaniniTest.Domain.Entities;
using API.StefaniniTest.Domain.Interfaces.Repositories;
using API.StefaniniTest.Domain.Notifications;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.StefaniniTest.Infrastructure.Repositories
{
    public class OrderRespository : IOrderRepository
    {
        private readonly ApiStefaniniTestDbContext _context;
        private readonly INotificationService _notifications;

        public OrderRespository(ApiStefaniniTestDbContext context, INotificationService notifications)
        {
            _context = context;
            _notifications = notifications;
        }

        public async Task Add(Pedido order)
        {
            _context.Pedidos.Add(order);
        }

        public async Task<Pedido> GetById(int id)
        {
            return await _context.Pedidos.Include(p => p.ItensPedidos)
                .ThenInclude(y => y.Produtos)
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task Update(Pedido order)
        {
            _context.Pedidos.Update(order);
        }

        public async Task Delete(Pedido order)
        {
            _context.Pedidos.Remove(order);
            await _context.SaveChangesAsync();
        }
    }
}
