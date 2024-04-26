using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using OpenIddict.Abstractions;
using OpenIddict.EntityFrameworkCore.Models;
using System.ComponentModel.DataAnnotations;
using static OpenIddict.Abstractions.OpenIddictConstants;

namespace MinhaEscola.Service.Identity.Web.Areas.Identity.Pages.Admin.Applications.Manage
{

    public class RegisterPageModel : PageModel
    {
        private readonly IOpenIddictApplicationManager _applicationManager;
        private readonly IOpenIddictAuthorizationManager _authorizationManager;

        public RegisterPageModel(IOpenIddictApplicationManager applicationManager, IOpenIddictAuthorizationManager authorizationManager)
        {
            _applicationManager = applicationManager;
            _authorizationManager = authorizationManager;
        }

        [BindProperty]
        public ApplicationModel Application { get; set; }

        public class ApplicationModel
        {
            [Required]
            [Display(Name = "Client Name")]
            public string ClientName { get; set; }

            [Required]
            [Display(Name = "Display name")]
            public string DisplayName { get; set; }

            [Required]
            [Display(Name = "Select the permissions")]
            public string[] Permissions { get; set; }

            [Required]
            [Display(Name = "Redirect Logout URI")]
            public string LogoutRedirectUri { get; set; }

            [Required]
            [Display(Name = "Redirect URI")]
            public string RedirectUri { get; set; }
        }

        public SelectList ListOfPermissions { get; set; }

        public void LoadSelects() {
            var permissions = new List<string> {
                OpenIddict.Abstractions.OpenIddictConstants.Permissions.Endpoints.Authorization,
                OpenIddict.Abstractions.OpenIddictConstants.Permissions.Endpoints.Token,
                OpenIddict.Abstractions.OpenIddictConstants.Permissions.Endpoints.Logout,
                OpenIddict.Abstractions.OpenIddictConstants.Permissions.Endpoints.Introspection,
                OpenIddict.Abstractions.OpenIddictConstants.Permissions.ResponseTypes.Code,
                OpenIddict.Abstractions.OpenIddictConstants.Permissions.ResponseTypes.CodeIdToken,
                OpenIddict.Abstractions.OpenIddictConstants.Permissions.ResponseTypes.CodeToken,
                OpenIddict.Abstractions.OpenIddictConstants.Permissions.ResponseTypes.None,
                OpenIddict.Abstractions.OpenIddictConstants.Permissions.GrantTypes.ClientCredentials,
                OpenIddict.Abstractions.OpenIddictConstants.Permissions.GrantTypes.AuthorizationCode
            };

            ListOfPermissions = new SelectList(permissions);
        }
        public void OnGet()
        {
            LoadSelects();
        }

       public async Task<IActionResult> OnPostAsync(string returnUrl = null)
       {
            var clientSecret = Guid.NewGuid().ToString();

            if (await _applicationManager.FindByClientIdAsync(Application.ClientName) is null)
            {
                var applicationDescriptor = new OpenIddictApplicationDescriptor
                {
                    ClientId = Application.ClientName,
                    ClientSecret = clientSecret,
                    DisplayName = Application.DisplayName,
                    ConsentType = ConsentTypes.Explicit,
                    RedirectUris =
                    {
                        new Uri(Application.RedirectUri)
                    },
                    PostLogoutRedirectUris =
                    {
                        new Uri("http://localhost:5026/Account/Logout")
                    },
                    Requirements =
                    {
                        Requirements.Features.ProofKeyForCodeExchange
                    }
                };

                HashSet<string> Permissions = new HashSet<string>() { };

                foreach (var item in Application.Permissions)
                {
                    applicationDescriptor.Permissions.Add(item);
                }

                await _applicationManager.CreateAsync(applicationDescriptor);
                

                TempData["Alert-Status"] = "200";
                TempData["Alert-Title"] = "Application created!";
                TempData["Alert-Subtitle"] = $"Application created with success, you client secret is {clientSecret} !";

                return RedirectToPage("Index");
            }
            else
            {
                TempData["Alert-Status"] = "500";
                TempData["Alert-Title"] = "Application Exists";
                TempData["Alert-Subtitle"] = $"Application not created already exists!";
            }

            return Page();
       }
    }
}
