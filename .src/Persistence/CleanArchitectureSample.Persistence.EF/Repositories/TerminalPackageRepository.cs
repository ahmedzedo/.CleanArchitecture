using CleanArchitectureSample.Domain.Entities;
using CleanArchitectureSample.Domain.Interfaces.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitectureSample.Persistence.EF.Repositories
{
    public class TerminalPackageRepository : Repository<TerminalPackage> , ITerminalPackageRepository
    {
        #region Constructors
        public TerminalPackageRepository(DbContext context):base(context)
        {

        }
        #endregion
    }
}
