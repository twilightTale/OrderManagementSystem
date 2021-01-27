using CustomerOrderManagement.Core.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace CustomerOrderManagement.Infrastructure.Repositories
{
  public class EntityBaseRepository<T> : IEntityBaseRepository<T> where T : class, new()
  {
	private OrderManagementDbContext dbContext;

	public EntityBaseRepository(OrderManagementDbContext _dbContext)
	{
	  dbContext = _dbContext;
	}

	public virtual IQueryable<T> GetAll()
	{
	  return dbContext.Set<T>();
	}

	public virtual IQueryable<T> All
	{
	  get
	  {
		return GetAll();
	  }
	}

	public virtual IQueryable<T> AllIncluding(params Expression<Func<T, object>>[] includeProperties)
	{
	  IQueryable<T> query = dbContext.Set<T>();
	  foreach (var includeProperty in includeProperties)
	  {
		query = query.Include(includeProperty);
	  }
	  return query;
	}

	public virtual IQueryable<T> FindBy(Expression<Func<T, bool>> predicate)
	{
	  return dbContext.Set<T>().Where(predicate);
	}

	public virtual void Add(T entity)
	{
	  dbContext.Add(entity);
	}

	public virtual void Edit(T entity)
	{
	  EntityEntry dbEntityEntry = dbContext.Update(entity);
	}

	public virtual void Delete(T entity)
	{
	  EntityEntry dbEntityEntry = dbContext.Remove(entity);
	  dbEntityEntry.State = EntityState.Deleted;
	}
  }
}