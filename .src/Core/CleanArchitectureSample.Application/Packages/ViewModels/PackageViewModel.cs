using CleanArchitectureSample.Application.Packages.Mapping;
using CleanArchitectureSample.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace CleanArchitectureSample.Application.Packages.ViewModels
{
    public class PackageViewModel
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }

        #region Mapping

        public static implicit operator Package(PackageViewModel viewModel)
        {
            return PackageViewModelMapper.ToModel(viewModel);
        }

        public static implicit operator PackageViewModel(Package model)
        {
            return PackageViewModelMapper.ToViewModel(model);
        }

        #endregion
    }
}
