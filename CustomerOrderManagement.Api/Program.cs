using CustomerOrderManagement.Api.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace CustomerOrderManagement.Api
{
  public class Program
  {
	public static void Main(string[] args)
	{
	  var host = CreateHostBuilder(args).Build();
	  Seed(host);
	  host.Run();
	}

	private static void Seed(IHost host)
	{
	  var scopeFactory = host.Services.GetService<IServiceScopeFactory>();
	  using (var scope = scopeFactory.CreateScope())
	  {
		var seeder = scope.ServiceProvider.GetService<Seeder>();
		//!Rekor: It will have some performance penalty on the startup and should actually moved to a separate thread.
		seeder.SeedAsync().Wait();
	  }
	}

	public static IHostBuilder CreateHostBuilder(string[] args) =>
		Host.CreateDefaultBuilder(args)
			.ConfigureWebHostDefaults(webBuilder =>
			{
			  webBuilder.UseStartup<Startup>();
			});
  }
}