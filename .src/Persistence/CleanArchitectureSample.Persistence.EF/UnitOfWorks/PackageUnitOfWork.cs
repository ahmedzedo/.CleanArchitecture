using CleanArchitectureSample.Domain.Interfaces.IRepositories;
using CleanArchitectureSample.Domain.Interfaces.IUnitOfWorks;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitectureSample.Persistence.EF.UnitOfWorks
{
    public class PackageUnitOfWork : UnitOfWork, IPackageUnitOfWork
    {
        #region Constructors
        public PackageUnitOfWork(DbContext context,
            IAttachmentRepository attachmentRepository,
            IPackageRepository packageRepository,
            IPackageConfigFileRepository packageConfigFileRepository,
            ITerminalPackageRepository terminalPackageRepository,
            ITerminalRepository terminalRepository) : base(context)
        {
            this.AttatchmentRepository = attachmentRepository;
            this.PackageRepository = packageRepository;
            this.PackageConfigFileRepository = packageConfigFileRepository;
            this.TerminalRepository = terminalRepository;
            this.TerminalPackageRepository = terminalPackageRepository;
        }
        #endregion

        #region Repositories
        public IAttachmentRepository AttatchmentRepository { get; }

        public IPackageRepository PackageRepository { get; }

        public IPackageConfigFileRepository PackageConfigFileRepository { get; }

        public ITerminalRepository TerminalRepository { get; }

        public ITerminalPackageRepository TerminalPackageRepository { get; } 
        #endregion
    }
}
