using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitectureSample.Infrastructure.UnitOfWork
{
  public interface IUnitOfWork
    {
        int Save(string userId = null);
        Task<int> SaveAsync(string userId = null);
    }
}
