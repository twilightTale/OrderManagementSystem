namespace CustomerOrderManagement.Core.Entities
{
  public class Product
  {
	public int ProductId { get; set; }
	public string ProductName { get; set; }
	public decimal PricePerItem { get; set; }

	public decimal AverageCustomerRating { get; set; }
  }
}