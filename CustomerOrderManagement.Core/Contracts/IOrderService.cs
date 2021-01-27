using CustomerOrderManagement.Core.Entities;
using System.Threading.Tasks;

namespace CustomerOrderManagement.Core.Contracts
{
  public interface IOrderService
  {
	Task<Order> SubmitOrder(Order order);
  }
}