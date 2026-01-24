using System.Text.Json;
using System.Text.Json.Serialization;
using Data;
using Extensions;
using Microsoft.EntityFrameworkCore;
using Options;
using Repositories;

var builder = WebApplication.CreateBuilder(args);

var isDevelopment = builder.Environment.IsDevelopment();

var configuration = builder.Configuration;

var services = builder.Services;

var clientAppPath = "ClientApp/dist";

var developmentServer = configuration["SpaDevelopmentServer"];

var authOptionsSection = configuration.GetSection(AuthOptions.Auth).Get<AuthOptions>()!;

services.AddSpaStaticFiles(options => { options.RootPath = clientAppPath; });

services.AddControllers().AddJsonOptions(opts =>
    {
        opts.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter(JsonNamingPolicy.CamelCase, allowIntegerValues: false));
    });

services.AddSecurity(authOptionsSection);

services.AddBff();

builder.Services.AddDbContext<ApplicationContext>(options =>
{
    var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

    options.UseMySql(connectionString, new MySqlServerVersion(new Version(8, 3, 0)));
});

services.AddScoped<IUserRepository, UserRepository>();
services.AddScoped<IProfileRepository, ProfileRepository>();

services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblyContaining<Program>());

var app = builder.Build();

app.UseHttpsRedirection();

app.UseSpaStaticFiles(
    new StaticFileOptions
    {
        OnPrepareResponse = context =>
        {
            if (context.Context.Request.Path.ToString().Contains("index.html", StringComparison.InvariantCultureIgnoreCase))
            {
                context.Context.Response.Redirect("/");
            }
        }
    }
);

app.UseRouting();

app.UseAuthentication();

app.UseBff();

app.UseAuthorization();

app.MapControllers().RequireAuthorization().AsBffApiEndpoint();

app.UseEndpoints(_ => {});

app.MapBffManagementEndpoints();

app.UseSpa(
    spa =>
    {
        var developmentServer = app.Configuration["SpaDevelopmentServer"];

        if (string.IsNullOrEmpty(developmentServer))
        {
            spa.Options.SourcePath = clientAppPath;

            return;
        }

        spa.UseProxyToSpaDevelopmentServer(developmentServer);
    }
);

app.Run();
