using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using OpenIddict.Abstractions;

namespace MinhaEscola.Service.Identity.Web.Areas.Identity.Pages.Admin.Applications.Manage
{
    public class IndexModel : PageModel
    {

        private readonly IOpenIddictApplicationManager _applicationManager;
        private readonly IOpenIddictAuthorizationManager _authorizationManager;

        public IndexModel(IOpenIddictApplicationManager applicationManager, IOpenIddictAuthorizationManager authorizationManager)
        {
            _applicationManager = applicationManager;
            _authorizationManager = authorizationManager;
        }

        public long QuantityApplications { get; set; }
        public long QuantityApplicationsAuthorizeds { get; set; }
        public long QuantityApplicationsNotAuthorizeds { get; set; }
        //public IEnumerable<object> AllApplications { get; set; }

        public async Task<IActionResult> OnGetAsync(string userId, string code)
        {
            QuantityApplications = await _applicationManager.CountAsync();
            QuantityApplicationsAuthorizeds = await _authorizationManager.CountAsync();
            QuantityApplicationsNotAuthorizeds = (QuantityApplications - QuantityApplicationsAuthorizeds);
            
            return Page();
        }

        public async Task<IActionResult> OnGetDeleteAsync(string identifier)
        {
            var application = await _applicationManager.FindByClientIdAsync(identifier);
            await _applicationManager.DeleteAsync(application);

            TempData["Alert-Status"] = "200";
            TempData["Alert-Title"] = "Application deleted!";
            TempData["Alert-Subtitle"] = $"The application {identifier} deleted !";

            return RedirectToPage("Index");
        }
    }
}
