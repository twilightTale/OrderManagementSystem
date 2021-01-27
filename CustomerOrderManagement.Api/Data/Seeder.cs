using CustomerOrderManagement.Core.Entities;
using CustomerOrderManagement.Infrastructure;
using Microsoft.AspNetCore.Hosting;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerOrderManagement.Api.Data
{
  public class Seeder
  {
	private OrderManagementDbContext _ctx;
	private readonly IWebHostEnvironment _hosting;

	public Seeder(IWebHostEnvironment hosting, OrderManagementDbContext ctx)
	{
	  _ctx = ctx;
	  _hosting = hosting;
	}

	/// <summary>
	/// Seed method to
	/// </summary>
	/// <returns></returns>
	public async Task SeedAsync()
	{
	  _ctx.Database.EnsureCreated();
	  if (!_ctx.Customers.Any())
	  {
		var filepath = Path.Combine(_hosting.ContentRootPath, "Data/customers.json");
		var json = File.ReadAllText(filepath);
		var customers = JsonConvert.DeserializeObject<IEnumerable<Customer>>(json);
		_ctx.Customers.AddRange(customers);
	  }

	  if (!_ctx.Products.Any())
	  {
		var filepath = Path.Combine(_hosting.ContentRootPath, "Data/products.json");
		var json = File.ReadAllText(filepath);
		var products = JsonConvert.DeserializeObject<IEnumerable<Product>>(json);
		_ctx.Products.AddRange(products);
	  }
	  _ctx.SaveChanges();
	}
  }
}