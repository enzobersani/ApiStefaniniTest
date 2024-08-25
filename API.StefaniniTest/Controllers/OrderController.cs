using API.StefaniniTest.Controllers.Base;
using API.StefaniniTest.Domain.Commands;
using API.StefaniniTest.Domain.Models.Response;
using API.StefaniniTest.Domain.Notifications;
using API.StefaniniTest.Domain.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.StefaniniTest.Controllers
{
    [Route("pedido")]
    public class OrderController : ApiControllerBase
    {
        private readonly IMediator _mediator;
        public OrderController(IMediator mediator, INotificationService notifications) : base(notifications)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Cadastro de pedido. Possível informar itens juntamente com o novo pedido.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(typeof(BaseResponseModel), 201)]
        [ProducesResponseType(typeof(Notification), 400)]
        [Produces("application/json")]
        public async Task<IActionResult> Create([FromBody] UpsertOrderCommand request)
            => Response(await _mediator.Send(request), 201);

        /// <summary>
        /// Exclusão do pedido por Id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(typeof(Notification), 400)]
        public async Task<IActionResult> Delete(int id)
            => Response(await _mediator.Send(new DeleteOrderCommand(id)), 204);

        /// <summary>
        /// Exclusão de itens do pedido por Id.
        /// </summary>
        /// <param name="orderId"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpDelete("{orderId}/itens")]
        [ProducesResponseType(204)]
        [ProducesResponseType(typeof(Notification), 400)]
        public async Task<IActionResult> DeleteItems(int orderId, [FromBody] DeleteOrderItemsCommand request)
        {
            request.IdPedido = orderId;
            return Response(await _mediator.Send(request), 204);
        }

        /// <summary>
        /// Consulta pedidos por Lista de Id.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpGet()]
        [ProducesResponseType(typeof(SearchOrderResponseModel), 200)]
        [ProducesResponseType(typeof(Notification), 400)]
        public async Task<IActionResult> Search([FromQuery] SearchOrdersQuery request)
            => Response(await _mediator.Send(request), 200);

        /// <summary>
        /// Alterar situação do pedido. Pago ou não pago.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        [ProducesResponseType(typeof(ChangesSituationOrderResponseModel), 200)]
        [ProducesResponseType(typeof(Notification), 400)]
        public async Task<IActionResult> Update(int id, [FromBody] ChangesSituationOrderCommand request)
        {
            request.Id = id;
            return Response(await _mediator.Send(request), 200);
        }
    }
}
