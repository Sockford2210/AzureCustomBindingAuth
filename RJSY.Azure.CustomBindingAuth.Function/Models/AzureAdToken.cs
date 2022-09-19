using System.Security.Claims;

namespace RJSY.Azure.CustomBindingAuth.Function.Models
{
    public class AzureAdToken
    {
        public ClaimsPrincipal User { get; set; }
    }
}
