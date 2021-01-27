using System.ComponentModel.DataAnnotations.Schema;

namespace CustomerOrderManagement.Core.Entities
{
  public class Customer
  {
	[DatabaseGenerated(DatabaseGeneratedOption.None)]
	public int CustomerId { get; set; }

	public string CustomerName { get; set; }
	public string AddressLine1 { get; set; }
	public string AddressLine2 { get; set; }
	public string City { get; set; }
	public string State { get; set; }
	public string Zip { get; set; }
	public string Country { get; set; }
	//public ICollection<Order> Orders { get; set; }
  }
}