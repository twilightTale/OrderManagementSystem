using System;
using System.Linq;
using System.Linq.Expressions;

namespace CustomerOrderManagement.Core.Persistence
{
  public interface IEntityBaseRepository<T> where T : class, new()
  {
	IQueryable<T> AllIncluding(params Expression<Func<T, object>>[] includeProperties);

	IQueryable<T> All { get; }

	IQueryable<T> GetAll();

	IQueryable<T> FindBy(Expression<Func<T, bool>> predicate);

	void Add(T entity);

	void Delete(T entity);

	void Edit(T entity);
  }
}