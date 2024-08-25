using API.StefaniniTest.Domain.Models.Response;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.StefaniniTest.Domain.Queries
{
    public class SearchOrdersQuery : IRequest<List<SearchOrderResponseModel>>
    {
        public List<int> Id { get; set; }
    }
}
