using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace MinhaEscola.Service.Identity.Web.ViewModel
{
    public class AuthorizeViewModel
    {
        [Display(Name = "Application")]
        public string ApplicationName { get; set; }

        [Display(Name = "Scope")]
        public string Scope { get; set; }
    }
}
