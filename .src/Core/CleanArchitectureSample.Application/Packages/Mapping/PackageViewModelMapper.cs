using CleanArchitectureSample.Application.Packages.ViewModels;
using CleanArchitectureSample.Domain.Entities;
using CleanArchitectureSample.Infrastructure.Mapping;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArchitectureSample.Application.Packages.Mapping
{
    public static class PackageViewModelMapper
    {
        public static Package ToModel(PackageViewModel viewModel)
        {
            return new Package
            {
                Id = viewModel.Id,
                Name = viewModel.Name,
                Description = viewModel.Description
            };
        }

        public static PackageViewModel ToViewModel(Package model)
        {
            return new PackageViewModel
            {
                Id = model.Id,
                Name = model.Name,
                Description = model.Description
            };
        }
    }
}
