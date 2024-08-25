using API.StefaniniTest.Domain.Interfaces.Repositories;
using API.StefaniniTest.Domain.Interfaces.UnitOfWork;
using API.StefaniniTest.Domain.Notifications;
using API.StefaniniTest.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.StefaniniTest.Infrastructure.UnitIOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApiStefaniniTestDbContext _context;
        private readonly INotificationService _notifications;
        private IProductRepository _productRepository;
        private IOrderRepository _orderRepository;

        public UnitOfWork(ApiStefaniniTestDbContext context, INotificationService notifications)
        {
            _context = context;
            _notifications = notifications;
        }

        public IProductRepository ProductRepository
            => _productRepository ??= new ProductRepository(_context, _notifications);

        public IOrderRepository OrderRepository
            => _orderRepository ??= new OrderRespository(_context, _notifications);

        public async Task<bool> CommitAsync()
        {
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                _notifications.AddNotification("CommitAsync", $"Ocorreu um erro ao salvar {ex.ToString()}");
                return false;
            }

            return true;
        }
    }
}
