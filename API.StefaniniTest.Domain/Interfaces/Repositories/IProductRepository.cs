using API.StefaniniTest.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.StefaniniTest.Domain.Interfaces.Repositories
{
    public interface IProductRepository
    {
        Task<List<Produto>> GetAll();
        Task<Produto> GetById(int id);
        Task Add(Produto produto);
        Task Update(Produto produto);
        Task Delete(Produto produto);
        Task<List<Produto>> GetByNameContains(string nomeProduto);
    }
}
