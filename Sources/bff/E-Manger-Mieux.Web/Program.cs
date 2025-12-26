
using Data;
using Extensions;
using Microsoft.EntityFrameworkCore;
using Repositories;

var builder = WebApplication.CreateBuilder(args);

var isDevelopment = builder.Environment.IsDevelopment();

var configuration = builder.Configuration;

var services = builder.Services;

var clientAppPath = "ClientApp/dist";

var developmentServer = configuration["spaDevelopmentServer"];

services.AddSpaStaticFiles(options => { options.RootPath = clientAppPath; });

services.AddControllers();

services.AddSecurity();

services.AddBff();

builder.Services.AddDbContext<ApplicationContext>(options =>
{
    var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

    options.UseMySql(connectionString, new MySqlServerVersion(new Version(8, 3, 0)));
});

services.AddScoped<IUserRepository, UserRepository>();

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
        var developmentServer = app.Configuration["spaDevelopmentServer"];

        if (string.IsNullOrEmpty(developmentServer))
        {
            spa.Options.SourcePath = clientAppPath;

            return;
        }

        spa.UseProxyToSpaDevelopmentServer(developmentServer);
    }
);

app.Run();
