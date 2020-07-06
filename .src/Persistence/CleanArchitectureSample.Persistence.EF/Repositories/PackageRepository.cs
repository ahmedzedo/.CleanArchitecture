using CleanArchitectureSample.Domain.Entities;
using CleanArchitectureSample.Domain.Interfaces.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitectureSample.Persistence.EF.Repositories
{
    public class PackageRepository : Repository<Package>, IPackageRepository
    {
        #region Constructors
        public PackageRepository(DbContext context) : base(context)
        {

        }
        #endregion
    }
}
