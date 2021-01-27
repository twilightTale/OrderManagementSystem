using CustomerOrderManagement.Core.Persistence;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace CustomerOrderManagement.Infrastructure.Persistence
{
  public class DbContextUnitOfWork : IUnitOfWork
  {
	private readonly DbContext Context;

	/// <summary>
	/// For a project with microservices dealing with many dbs, we may want to create a unit of work factory class
	/// to generate dbContextUnitofWork.
	/// </summary>
	/// <param name="context"></param>
	public DbContextUnitOfWork(OrderManagementDbContext context)
	{
	  Context = context;
	}

	public void Dispose()
	{
	  Context.Dispose();
	}

	public Task SaveChangesAsync()
	{
	  try
	  {
		//Rekor:  do validation using validation context before saving changes.
		return Context.SaveChangesAsync();
	  }
	  catch (DbUpdateException)
	  {
		throw;
	  }
	}
  }
}