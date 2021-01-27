using CustomerOrderManagement.Core.Entities;
using CustomerOrderManagement.Core.Persistence;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;

namespace CustomerOrderManagement.Api.Controllers
{
  [ApiController]
  [Route("[controller]")]
  public class CustomerController : ControllerBase
  {
	private readonly ILogger<CustomerController> _logger;
	private readonly IUnitOfWork _uow;
	private readonly IEntityBaseRepository<Customer> _Customer;

	public CustomerController(ILogger<CustomerController> logger, IEntityBaseRepository<Customer> customer, IUnitOfWork uow)
	{
	  _logger = logger;
	  _uow = uow;
	  _Customer = customer;
	}

	/// <summary>
	/// Return the list of customers
	/// </summary>
	/// <returns></returns>
	[HttpGet]
	public IEnumerable<Customer> Get()
	{
	  return _Customer.All;
	}
  }
}