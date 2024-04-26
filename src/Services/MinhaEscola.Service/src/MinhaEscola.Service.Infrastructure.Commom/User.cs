
using Microsoft.AspNetCore.Http;

namespace MinhaEscola.Service.Infrastructure.Commom
{
    public static class User
    {
        public static string GetUserId(this IHttpContextAccessor context) {
            return context.HttpContext!.User.Claims.FirstOrDefault(x => x.Type == "sub")!.Value;
        }
    }
}
