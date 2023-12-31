using DAL.Services.SqlService;
using System.Data;
using System.Data.SqlClient;
using Tastelio.Client.Pages;
using Tastelio.Components;
using Tastelio.ViewModel.Home;

namespace Tastelio
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);

			// Add services to the container.
			builder.Services.AddRazorComponents()
				.AddInteractiveServerComponents()
				.AddInteractiveWebAssemblyComponents();

			string dbConnectionString = builder.Configuration.GetValue<string>("ConnectionStrings:TastelioDb") ?? string.Empty;
			builder.Services.AddTransient<IDbConnection>((sp) => new SqlConnection(dbConnectionString));

			builder.Services.AddScoped<IHomeViewModel, HomeViewModel>();

			builder.Services.AddSingleton<ISqlService, SqlService>();

			var app = builder.Build();

			// Configure the HTTP request pipeline.
			if (app.Environment.IsDevelopment())
			{
				app.UseWebAssemblyDebugging();
			}
			else
			{
				app.UseExceptionHandler("/Error");
				// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
				app.UseHsts();
			}

			app.UseHttpsRedirection();

			app.UseStaticFiles();
			app.UseAntiforgery();

			app.MapRazorComponents<App>()
				.AddInteractiveServerRenderMode()
				.AddInteractiveWebAssemblyRenderMode()
				.AddAdditionalAssemblies(typeof(Counter).Assembly);

			app.Run();
		}
	}
}
