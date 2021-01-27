using CustomerOrderManagement.Core.Entities;
using CustomerOrderManagement.Core.Persistence;
using System.Threading.Tasks;

namespace CustomerOrderManagement.Core.Services
{
  public class OrderService
  {
	private readonly IEntityBaseRepository<Order> _order;
	private readonly IUnitOfWork _uow;

	public OrderService(IEntityBaseRepository<Order> order, IUnitOfWork uow)
	{
	  _order = order;
	  _uow = uow;
	}

	public async Task<Order> SubmitOrder(Order order)
	{
	  _order.Add(order);
	  await _uow.SaveChangesAsync();
	  return order;
	}
  }
}