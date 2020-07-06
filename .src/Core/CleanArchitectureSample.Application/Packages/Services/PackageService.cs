using CleanArchitectureSample.Application.Packages.ViewModels;
using CleanArchitectureSample.Application.ViewModels;
using CleanArchitectureSample.Domain.Entities;
using CleanArchitectureSample.Domain.Interfaces.IUnitOfWorks;
using CleanArchitectureSample.Infrastructure.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace CleanArchitectureSample.Application.Packages.Services
{
    public class PackageService : IPackageService
    {
        private readonly IPackageUnitOfWork UnitOfWork;

        #region Constructor

        public PackageService(IPackageUnitOfWork unitOfWork)
        {
            this.UnitOfWork = unitOfWork;
        }

        #endregion

        #region Public Methods
        public async Task<Response<PackageViewModel>> AddAsync(Request<PackageViewModel> request)
        {
            Response<PackageViewModel> response = null;

            if (request is null || (!(request is null) && request.Data is null))
            {
                return response.CreateFailedResponse(ErrorTypes.BadRequest, "Bad Request");
            }
            var newPackage = request.Data;

            if (await UnitOfWork.PackageRepository.AnyAsync(p => p.Name == newPackage.Name))
            {
                return response.CreateFailedResponse(ErrorTypes.ItemAlreadyExist, $"{newPackage.Name} package is already exist");
            }

            Package result = await UnitOfWork.PackageRepository.AddAsync(request.Data);
            await UnitOfWork.SaveAsync();

            return new Response<PackageViewModel>
            {
                Data = result,
                Success = true,
                Message = "Ok"
            };
        }

        public async Task<Response<PackageViewModel>> EditAsync(Request<PackageViewModel> request)
        {
            Response<PackageViewModel> response = null;

            if (request is null)
            {
                return response.CreateFailedResponse(ErrorTypes.BadRequest, "Bad Request");
            }
            var newPackage = request.Data;
            var packages = await UnitOfWork.PackageRepository.GetAsync(p => p.Id == newPackage.Id || (p.Name == newPackage.Name && p.Id != newPackage.Id));

            if (packages.Count < 1)
            {
                return response.CreateFailedResponse(ErrorTypes.ItemNotFound, $"{newPackage.Name} package is not Found");
            }
            else if (packages.Count > 1)
            {
                return response.CreateFailedResponse(ErrorTypes.ItemAlreadyExist, $"{newPackage.Name} package is already exist");
            }
            var orginalPackage = packages.FirstOrDefault();
            orginalPackage = newPackage;

            UnitOfWork.PackageRepository.Update(orginalPackage);

            if (await UnitOfWork.SaveAsync(request.UserName) > 0)
            {
                response = new Response<PackageViewModel>
                {
                    Success = true,
                    Message = "ok"
                };

                return response;
            }
            else
            {
                return response.CreateFailedResponse(ErrorTypes.ItemNotFound, "Edite item faild");
            }
        }

        public async Task<Response<PackageViewModel>> FindByIdAsync(int? id)
        {
            Response<PackageViewModel> response = null;

            if (id is null)
            {
                return response.CreateFailedResponse(ErrorTypes.BadRequest, "Bad Request");

            }
            var Package = await UnitOfWork.PackageRepository.GetByIdAsync(id);

            if (Package is null)
            {
                return response.CreateFailedResponse(ErrorTypes.ItemNotFound, $"{Package.Name} package is not Found");
            }
            response = new Response<PackageViewModel>
            {
                Data = Package,
                Success = true,
                Message = "ok"
            };

            return response;
        }

        public async Task<SearchResponse<PackageIndexViewModel>> SearchAsync(SearchRequest<PackageIndexViewModel> request)
        {
            SearchResponse<PackageIndexViewModel> response = null;

            if (request is null)
            {
                return response.CreateFailedResponse(ErrorTypes.BadRequest, "Bad Request");
            }

            List<Expression<Func<Package, bool>>> filters = GetPackageSearchFilters(request);

            (IEnumerable<Package> items, int totalCount) = await UnitOfWork.PackageRepository.GetPagedByFiltersAsync(request.PageIndex, request.PageSize, filters, o => o.OrderByDescending(p => p.Id));

            response = new SearchResponse<PackageIndexViewModel>
            {
                Data = request.Data ?? new PackageIndexViewModel(),
                TotalItemsCount = totalCount,
                PageIndex = request.PageIndex,
                Success = true,
                Message = "ok"
            };
            response.Data.Results = items.ToList();

            return response;
        }


        #endregion

        #region Helper Methods
        private static List<Expression<Func<Package, bool>>> GetPackageSearchFilters(SearchRequest<PackageIndexViewModel> request)
        {
            var filters = new List<Expression<Func<Package, bool>>>();

            if (!string.IsNullOrEmpty(request.Data?.Name))
            {
                filters.Add(f => f.Name.Contains(request.Data.Name));
            }

            if (!string.IsNullOrEmpty(request.Data?.Description))
            {
                filters.Add(f => f.Description.Contains(request.Data.Description));
            }

            return filters;
        }
        #endregion

    }
}
