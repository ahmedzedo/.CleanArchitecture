using CleanArchitectureSample.Application.Packages.Services;
using CleanArchitectureSample.Application.ViewModels;
using CleanArchitectureSample.Infrastructure.Messaging;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;

namespace CleanArchitectureSample.Presentation.UI.Web.Areas.Packages.Pages
{
    public class IndexModel : PageModel
    {
        #region Dependencies
        private readonly IPackageService PackageService;
        #endregion

        #region Constructors
        public IndexModel(IPackageService packageService)
        {
            PackageService = packageService;
        }
        #endregion

        #region Properties

        #region Bind Prpoerties
        [BindProperty(SupportsGet = true)]
        public SearchRequest<PackageIndexViewModel> SearchPackageRequest { get; set; } = new SearchRequest<PackageIndexViewModel>();

        [BindProperty]
        public SearchResponse<PackageIndexViewModel> SearchPackageResponse { get; set; } = new SearchResponse<PackageIndexViewModel>();
        #endregion

        #endregion

        #region Handlers
        public async Task OnGetAsync()
        {
            PrepareRequest();

            var response = await PackageService.SearchAsync(SearchPackageRequest);

            if (response.Success)
            {
                SearchPackageResponse.Data = response.Data;
                SearchPackageResponse.PageIndex = SearchPackageRequest.PageIndex = response.PageIndex;
                SearchPackageResponse.TotalItemsCount = response.TotalItemsCount;
            }
        }


        #endregion

        #region Helper Method
        private void PrepareRequest()
        {
            SearchPackageRequest.PagePerPages = 3;
            SearchPackageRequest.PageSize = 10;
            SearchPackageRequest.UserName = HttpContext.User?.Identity.Name ?? "";
        }
        #endregion


    }
}
