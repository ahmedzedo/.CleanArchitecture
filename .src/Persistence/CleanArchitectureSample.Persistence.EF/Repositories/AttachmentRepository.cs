using CleanArchitectureSample.Domain.Entities;
using CleanArchitectureSample.Domain.Interfaces.IRepositories;
using CleanArchitectureSample.Infrastructure.Domain;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitectureSample.Persistence.EF.Repositories
{
    public class AttachmentRepository : Repository<Attatchment>, IAttachmentRepository
    {
        #region Constructors
        public AttachmentRepository(DbContext context) : base(context)
        {

        } 
        #endregion

    }
}
