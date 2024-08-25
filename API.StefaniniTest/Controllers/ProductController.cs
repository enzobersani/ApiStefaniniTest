using API.StefaniniTest.Controllers.Base;
using API.StefaniniTest.Domain.Commands;
using API.StefaniniTest.Domain.Models.Response;
using API.StefaniniTest.Domain.Notifications;
using API.StefaniniTest.Domain.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.StefaniniTest.Controllers
{
    [Route("api/product")]
    public class ProductController : ApiControllerBase
    {
        private readonly IMediator _mediator;
        public ProductController(IMediator mediator, INotificationService notifications) : base(notifications)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Cadastro de produto.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(typeof(BaseResponseModel), 201)]
        [ProducesResponseType(typeof(Notification), 400)]
        [Produces("application/json")]
        public async Task<IActionResult> Create([FromBody] InsertProductCommand request)
            => Response(await _mediator.Send(request), 201);

        /// <summary>
        /// Atualização de produto.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        [ProducesResponseType(typeof(ProductResponseModel), 200)]
        [ProducesResponseType(typeof(Notification), 400)]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateProductCommand request)
        {
            request.Id = id;
            return Response(await _mediator.Send(request), 200);
        }

        /// <summary>
        /// Buscar de produtos por Nome.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpGet()]
        [ProducesResponseType(typeof(ProductResponseModel), 200)]
        [ProducesResponseType(typeof(Notification), 400)]
        public async Task<IActionResult> Search([FromQuery] SearchProductQuery request)
            => Response(await _mediator.Send(request), 200);

        /// <summary>
        /// Exclusão de produto por Id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(typeof(Notification), 400)]
        public async Task<IActionResult> Delete(int id)
            => Response(await _mediator.Send(new DeleteProductCommand(id)), 204);
    }
}
