using CleanArchitectureSample.Domain.Interfaces.IRepositories;
using CleanArchitectureSample.Infrastructure.UnitOfWork;

namespace CleanArchitectureSample.Domain.Interfaces.IUnitOfWorks
{
    public interface IPackageUnitOfWork : IUnitOfWork
    {
        IAttachmentRepository AttatchmentRepository { get; }
        IPackageRepository PackageRepository { get; }
        IPackageConfigFileRepository PackageConfigFileRepository { get; }
        ITerminalRepository TerminalRepository { get; }
        ITerminalPackageRepository TerminalPackageRepository { get; }
    }
}
