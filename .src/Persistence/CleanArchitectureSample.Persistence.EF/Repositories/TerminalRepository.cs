using CleanArchitectureSample.Domain.Entities;
using CleanArchitectureSample.Domain.Interfaces.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitectureSample.Persistence.EF.Repositories
{
    public class TerminalRepository : Repository<Terminal>,ITerminalRepository
    {
        #region Constructors
        public TerminalRepository(DbContext context):base(context)
        {

        }
        #endregion
    }
}
