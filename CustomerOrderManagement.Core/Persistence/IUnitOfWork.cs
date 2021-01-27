using System;
using System.Threading.Tasks;

namespace CustomerOrderManagement.Core.Persistence
{
  public interface IUnitOfWork : IDisposable
  {
	Task SaveChangesAsync();
  }
}