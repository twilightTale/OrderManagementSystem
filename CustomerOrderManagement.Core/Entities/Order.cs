using System;

namespace CustomerOrderManagement.Core.Entities
{
  public class Order
  {
	public int OrderId { get; set; }
	public Product Product { get; set; }
	public int ProductId { get; set; }
	public Customer Customer { get; set; }
	public int CustomerId { get; set; }
	public DateTime OrderDate { get; set; }
	public DateTime? ShippedDate { get; set; }
	public decimal PricePaid { get; set; }
	public int Quantity { get; set; }
  }
}