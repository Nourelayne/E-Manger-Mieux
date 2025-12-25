
var builder = WebApplication.CreateBuilder(args);

var isDevelopment = builder.Environment.IsDevelopment();
var configuration = builder.Configuration;
var services = builder.Services;

var clientAppPath = "ClientApp/dist";

var developmentServer = configuration["spaDevelopmentServer"];

services.AddSpaStaticFiles(options => { options.RootPath = clientAppPath; });
services.AddControllers();

services.AddAuthentication(options =>
{
    options.DefaultScheme = "Cookies";
    options.DefaultChallengeScheme = "oidc";
})
.AddCookie("Cookies", options =>
{
    options.Cookie.Name = "__Host-bff";
    options.Cookie.SameSite = SameSiteMode.Strict;
    options.ExpireTimeSpan = TimeSpan.FromMinutes(1);
    options.SlidingExpiration = true;
})
.AddOpenIdConnect("oidc", options =>
{
    options.Authority = "https://dev-8z41vb754k67uvx5.us.auth0.com";
    options.ClientId = "0UIBKg9lg2EVhKffyM9sH9V34g80wBns";
    options.ClientSecret = "gIxDVUjW86s7ZVWL4071P8GodTPK0nwbNGWJdU9xMlGf86ZkKkDzo-ZOW-UfsTJ9";
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
});

services.AddBff();

var app = builder.Build();

app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthentication();
app.UseBff();
app.UseAuthorization();

app.MapControllers().RequireAuthorization().AsBffApiEndpoint();
app.MapBffManagementEndpoints();

if (string.IsNullOrWhiteSpace(developmentServer))
{
    app.UseSpaStaticFiles();
}

app.MapWhen(ctx =>
    !ctx.Request.Path.StartsWithSegments("/bff") &&
    !ctx.Request.Path.StartsWithSegments("/api"),
spaApp =>
{
    spaApp.UseSpa(spa =>
    {
        if (!string.IsNullOrWhiteSpace(developmentServer))
        {
            spa.UseProxyToSpaDevelopmentServer(developmentServer);
        }
        else
        {
            spa.Options.SourcePath = clientAppPath;
        }
    });
});


app.Run();
