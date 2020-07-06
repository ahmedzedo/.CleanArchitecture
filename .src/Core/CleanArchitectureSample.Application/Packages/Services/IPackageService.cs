using CleanArchitectureSample.Application.Packages.ViewModels;
using CleanArchitectureSample.Application.ViewModels;
using CleanArchitectureSample.Domain.Entities;
using CleanArchitectureSample.Infrastructure.Messaging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitectureSample.Application.Packages.Services
{
    public interface IPackageService
    {
        Task<SearchResponse<PackageIndexViewModel>> SearchAsync(SearchRequest<PackageIndexViewModel> request);
        Task<Response<PackageViewModel>> AddAsync(Request<PackageViewModel> request);
        Task<Response<PackageViewModel>> FindByIdAsync(int? id);
        Task<Response<PackageViewModel>> EditAsync(Request<PackageViewModel> request);
    }
}
