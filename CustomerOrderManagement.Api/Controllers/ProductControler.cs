using CustomerOrderManagement.Core.Entities;
using CustomerOrderManagement.Core.Persistence;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Linq;

namespace CustomerOrderManagement.Api.Controllers
{
  [ApiController]
  [Route("api/product")]
  public class ProductControler : ControllerBase
  {
	private readonly ILogger<OrderController> _logger;
	private readonly IEntityBaseRepository<Product> _product;

	public ProductControler(ILogger<OrderController> logger, IEntityBaseRepository<Product> product)
	{
	  _logger = logger;
	  _product = product;
	}

	/// <summary>
	/// Get the list of products with AverageCustomerRating in the order of highest to lowest ratings.
	/// </summary>
	/// <returns></returns>
	[HttpGet("Get")]
	public IActionResult GetProducts(int pageIndex, int pageSize = 10)
	{
	  // Use paging to avoid transfer huge data over the wire.
	  var popularProducts = _product.All.OrderByDescending(x => x.AverageCustomerRating)
		.ThenBy(x => x.ProductName)
		.Skip(pageIndex * pageSize)
		.Take(pageSize)
		.Select(x => new
		{
		  x.ProductId,
		  x.ProductName,
		  x.PricePerItem,
		  x.AverageCustomerRating
		});

	  return Ok(popularProducts);
	}
  }
}