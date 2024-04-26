using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MinhaEscola.Service.Identity.Web.Models;
using OpenIddict.Abstractions;
using OpenIddict.Server.AspNetCore;
using OpenIddict.Validation.AspNetCore;
using System.Data.Entity;
using static OpenIddict.Abstractions.OpenIddictConstants;

namespace MinhaEscola.Service.Identity.Web.Controllers
{
    [Route("api")]
    public class AuthenticationController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<Role> _roleManager;
        private readonly IUserStore<User> _userStore;

        public AuthenticationController(UserManager<User> userManager, RoleManager<Role> roleManager, IUserStore<User> userStore)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _userStore = userStore;
        }

        [Authorize(AuthenticationSchemes = OpenIddictValidationAspNetCoreDefaults.AuthenticationScheme)]
        [HttpGet("authentication/update-profile")]
        public async Task<IActionResult> UpdateProfile(string profile)
        {
            var user = await _userManager.FindByIdAsync(User.GetClaim(Claims.Subject));
            var role = _roleManager.Roles.First(x => x.Name == profile);

            if (role == null) {
                return BadRequest("This role not already!");
            }

            var result = await _userManager.AddToRoleAsync(user, role.Name.ToUpper());
            await _userManager.RemoveFromRoleAsync(user, "CLIENT");

            return Ok();
        }
    }
}
