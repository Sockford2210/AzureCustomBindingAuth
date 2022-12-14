using System;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

namespace RJSY.Azure.CustomBindingAuth.Function.Bindings
{
    public static class AzureAdTokenBindingExtension
    {
        public static IWebJobsBuilder UseAzureAdTokenBinding(this IWebJobsBuilder builder)
        {
            _ = builder ?? throw new ArgumentNullException(nameof(builder));

            builder.AddExtension<AzureAdTokenBinding>();

            builder.Services.AddSingleton<ISecurityTokenValidator, JwtSecurityTokenHandler>();
            builder.Services.AddSingleton<AzureAdTokenValidationService>();

            return builder;
        }
    }
}
