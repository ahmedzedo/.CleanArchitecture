using CleanArchitectureSample.Domain.Entities;
using CleanArchitectureSample.Domain.Interfaces.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitectureSample.Persistence.EF.Repositories
{
    public class PackageConfigFileRepository : Repository<PackageConfigFile>, IPackageConfigFileRepository
    {
        #region Constructors
        public PackageConfigFileRepository(DbContext context) : base(context)
        {

        }
        #endregion
    }
}
