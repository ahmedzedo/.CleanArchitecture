using CleanArchitectureSample.Application.Packages.Services;
using CleanArchitectureSample.Application.Packages.ViewModels;
using CleanArchitectureSample.Infrastructure.Messaging;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;

namespace CleanArchitectureSample.Presentation.UI.Web.Areas.Packages.Pages
{
    public class EditModel : PageModel
    {
        private readonly IPackageService PackageService;

        public EditModel(IPackageService packageService)
        {
            PackageService = packageService;
        }

        [BindProperty(SupportsGet = true)]
        public int? Id { get; set; }
        [BindProperty]
        public Request<PackageViewModel> EditPackageRequest { get; set; } = new Request<PackageViewModel>();

        public async Task<IActionResult> OnGetAsync()
        {
            var response = await PackageService.FindByIdAsync(Id);

            if (!response.Success)
            {
                return RedirectToPage("./Index");
            }
            EditPackageRequest.Data = response.Data;

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var response = await PackageService.EditAsync(EditPackageRequest);

            if (response.Success)
            {
                return RedirectToPage("./Index");
            }

            return Page();
        }


    }
}
