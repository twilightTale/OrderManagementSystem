using CustomerOrderManagement.Core.Entities;
using CustomerOrderManagement.Core.Persistence;
using CustomerOrderManagement.Core.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerOrderManagement.Api.Controllers
{
  [ApiController]
  [Route("api/order")]
  public class OrderController : ControllerBase
  {
	private readonly ILogger<OrderController> _logger;
	private readonly OrderService _orderService;
	private readonly IEntityBaseRepository<Order> _order;

	public OrderController(ILogger<OrderController> logger, IEntityBaseRepository<Order> order,
						   OrderService orderService)
	{
	  _logger = logger;
	  _orderService = orderService;
	  _order = order;
	}

	/// <summary>
	/// Get all the pending orders which are not yet shipped to the customers
	/// </summary>
	/// <returns>CustomerId, CustomerName, OrderId, OrderDate, Quantity, PricePaid</returns>
	[HttpGet("Pending")]
	public IActionResult PendingOrders()
	{
	  ///Instead of returning anonymous type we can also return strongly type viewmodel.
	  ///There are different factors involved for the decision. We can also use a factory. Open for discussion.
	  var pendingOrders = _order.All.Where(x => x.ShippedDate == null).Select(x => new
	  {
		CustomerId = x.Customer.CustomerId,
		x.Customer.CustomerName,
		x.OrderId,
		x.OrderDate,
		x.Quantity,
		x.PricePaid
	  });
	  return Ok(pendingOrders);
	}

	[HttpGet("{id}")]
	public ActionResult<Order> OrderById(int id)
	{
	  var order = _order.FindBy(x => x.OrderId == id).FirstOrDefault();
	  if (order == null)
	  {
		return NotFound();
	  }
	  return order;
	}

	/// <summary>
	/// Adds new order
	/// </summary>
	/// <param name="order"></param>
	/// <returns></returns>
	[HttpPost("Submit")]
	public async Task<ActionResult<Order>> SubmitOrder(Order order)
	{
	  var createdOrder = await _orderService.SubmitOrder(order);
	  //HATEOS to discover new resource
	  return CreatedAtAction(nameof(OrderById), new { id = createdOrder.OrderId }, createdOrder);
	}
  }
}