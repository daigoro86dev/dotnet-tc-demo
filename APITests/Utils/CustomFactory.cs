using API;
using Infrastructure.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace APITests.Utils;

public class CustomFactory : WebApplicationFactory<Program>
{
    // Gives a fixture an opportunity to configure the application before it gets built.
    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        builder.ConfigureTestServices(services =>
        {
            // Remove AppDbContext
            services.RemoveDbContext<StoreContext>();

            // Add DB context pointing to test container
            services.AddDbContext<StoreContext>(options => { options.UseNpgsql("connection string"); });

            // Ensure schema gets created
            services.EnsureDbCreated<StoreContext>();
        });
    }
}