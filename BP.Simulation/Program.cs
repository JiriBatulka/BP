using System;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using BP.Simulation.Services;
using BP.Simulation.DTOs.Converters;
using BP.Simulation.Repositories;
using BP.Simulation.Shared;
using BP.Simulation.ViewModels;

namespace BP.Simulation
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            WebAssemblyHostBuilder builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("app");

            HttpClient client = new HttpClient()
            {
                BaseAddress = new Uri("https://localhost:51039/")
            };
            builder.Services.AddScoped(sp => client);

            AppSettings appSettings = builder.Configuration.Get<AppSettings>();
            builder.Services.AddSingleton(appSettings.NamesLists);
            builder.Services.AddTransient<GeneratorService>();
            builder.Services.AddTransient<CustomerDTOConverter>();
            builder.Services.AddTransient<DecryptionService>();
            builder.Services.AddTransient<CustomerRepository>();
            builder.Services.AddTransient<CustomerViewModel>();
            builder.Services.AddSingleton<EntitesLists>();
            await builder.Build().RunAsync();
        }
    }
}
