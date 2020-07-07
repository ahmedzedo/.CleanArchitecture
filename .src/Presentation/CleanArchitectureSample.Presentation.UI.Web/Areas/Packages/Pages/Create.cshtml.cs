using CleanArchitectureSample.Application.Packages.Services;
using CleanArchitectureSample.Application.Packages.ViewModels;
using CleanArchitectureSample.Infrastructure.Messaging;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;

namespace CleanArchitectureSample.Presentation.UI.Web.Areas.Packages.Pages
{
    public class CreateModel : PageModel
    {
        #region Dependencies
        private readonly IPackageService PackageService;
        #endregion

        #region Constructors
        public CreateModel(IPackageService packageService)
        {
            PackageService = packageService;
        }
        #endregion

        #region Bind Properties
        [BindProperty]
        public string Message { get; set; }

        [BindProperty]
        public Request<PackageViewModel> CreatePackageRequest { get; set; } = new Request<PackageViewModel>();

        #endregion

        #region Handlers

        #region Get
        public IActionResult OnGet()
        {
            return Page();
        }
        #endregion

        #region Post
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
          
            CreatePackageRequest.UserName = HttpContext.User?.Identity.Name ?? "anonymous";

            var response = await PackageService.AddAsync(CreatePackageRequest);
            Message = response.Message;

            if (!response.Success)
            {
                return Page();
            }

            return RedirectToPage("./Index");
        }
        #endregion

        #endregion
    }
}