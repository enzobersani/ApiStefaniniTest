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
    public class ProductRepository : IProductRepository
    {
        private readonly ApiStefaniniTestDbContext _context;
        private readonly INotificationService _notifications;

        public ProductRepository(ApiStefaniniTestDbContext context, INotificationService notifications)
        {
            _context = context;
            _notifications = notifications;
        }

        public async Task<List<Produto>> GetAll()
        {
            return await _context.Produtos.AsNoTracking().ToListAsync();
        }

        public async Task<Produto> GetById(int id)
        {
            return await _context.Produtos.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task Add(Produto produto)
        {
            _context.Produtos.Add(produto);
        }

        public async Task Update(Produto produto)
        {
            _context.Produtos.Update(produto);
        }

        public async Task Delete(Produto produto)
        {
            _context.Produtos.Remove(produto);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Produto>> GetByNameContains(string nomeProduto)
        {
            return await _context.Produtos
                .AsNoTracking()
                .Where(p => p.NomeProduto.Contains(nomeProduto))
                .ToListAsync();
        }
    }
}
