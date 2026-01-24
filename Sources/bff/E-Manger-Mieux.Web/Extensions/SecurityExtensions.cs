using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.AspNetCore.Http.HttpResults;
using Models.Entities;
using Options;
using Repositories;

namespace Extensions;

public static class SecurityExtensions
{
    public static void AddSecurity(this IServiceCollection services, AuthOptions authOptions) => 
        services.AddAuthentication(options =>
        {
            options.DefaultScheme = "Cookies";
            options.DefaultChallengeScheme = "oidc";
        })
        .AddCookie("Cookies", options =>
        {
            options.Cookie.Name = "__Host-bff";
            options.Cookie.SameSite = SameSiteMode.Strict;
            options.ExpireTimeSpan = TimeSpan.FromMinutes(15);
            options.SlidingExpiration = true;
        })
        .AddOpenIdConnect("oidc", options =>
        {
            options.Authority = authOptions.Authority;
            options.ClientId = authOptions.ClientId;
            options.ClientSecret = authOptions.ClientSecret;
            options.CallbackPath = new PathString("/authentication-callback");
            options.RequireHttpsMetadata = true;

            options.ResponseType = "code";
            options.UsePkce = true;

            options.GetClaimsFromUserInfoEndpoint = true;
            options.SaveTokens = true;

            options.Scope.Clear();
            options.Scope.Add("openid");
            options.Scope.Add("profile");
            options.Scope.Add("offline_access");

            options.Events.OnTokenValidated = OnTokenValidated;
        });
        
    public async static Task OnTokenValidated(TokenValidatedContext context)
    {
        var sub = context.Principal?.FindFirst(ClaimTypes.NameIdentifier)?.Value;

        if (string.IsNullOrEmpty(sub))
        {
            context.Fail("Missing 'sub' claim in OIDC token.");

            return;
        }

        var repository = context.HttpContext.RequestServices.GetRequiredService<IUserRepository>();

        var user = await repository.GetUserByAuthSubjectAsync(sub);

        if (user is null)
        {
            try
            {
                var userId = Guid.NewGuid();
                var profileId = Guid.NewGuid();
            
                await repository.CreateUserAsync(new User
                {
                    Id = Guid.NewGuid(),
                    AuthSubject = sub,
                    CreateAt = DateTimeOffset.Now,
                    IsVerified = false,
                    Profile = new Profile
                    {
                        Id = profileId,
                        UserId = userId,
                        AvatarUrl = context.Principal?.FindFirst("picture")?.Value,
                    }
                });
            }
            catch
            {
                context.Fail("User creation failed");
            }
        }

        context.Success();
    }
}