using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CleanArchitectureSample.Presentation.UI.Web.Areas.Packages.Pages
{
    public class TestModel : PageModel
    {
        [BindProperties]
        public class NestedViewModel
        {
           
            public string Address { get; set; }
            
            public string Contact { get; set; }

            public List<NestedViewModel> NestedList { get; set; }
        }

        public class ViewModel
        {
            public string Name { get; set; }
            public string Description { get; set; }
            public NestedViewModel NestedViewModel { get; set; }
        }
        public ViewModel Input { get; set; }

        [BindProperty]
        public NestedViewModel NestedModel { get; set; }

        public TestModel()
        {

        }
        public void OnGet()
        {
            Input = new ViewModel
            {
                NestedViewModel = new NestedViewModel
                {
                    NestedList = new List<NestedViewModel>()
                }
            };
        }

        public void OnPost()
        {
            if (ModelState.IsValid)
            {
                var x = NestedModel;
            }
        }
    }
}