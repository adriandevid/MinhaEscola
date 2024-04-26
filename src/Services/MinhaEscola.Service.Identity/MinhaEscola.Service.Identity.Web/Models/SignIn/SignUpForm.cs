using System.ComponentModel.DataAnnotations;

namespace MinhaEscola.Service.Identity.Web.Models.SignIn
{
    public class SignUpForm
    {
        public string Email { get; set; }


        public string Password { get; set; }

        public string RedirectUrl { get; set; }

        public bool RememberMe { get; set; }
    }
}
