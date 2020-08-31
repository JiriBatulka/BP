using System;
using System.Net.Http;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Text;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using BP.Services;
using System.IO;
using System.Text.Json;
using Microsoft.AspNetCore.Components;
using BP.DTOs.Converters;
using BP.Repositories;

namespace BP
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            WebAssemblyHostBuilder builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("app");

            HttpClient client = new HttpClient()
            {
                BaseAddress = new Uri("https://localhost:51333/")
            };
            builder.Services.AddScoped(sp => client);

            AppSettings appSettings = builder.Configuration.Get<AppSettings>();
            builder.Services.AddSingleton(appSettings.NamesLists);
            builder.Services.AddTransient<GeneratorService>();
            builder.Services.AddTransient<CustomerDTOConverter>();
            builder.Services.AddTransient<DecryptionService>();
            builder.Services.AddTransient<CustomerRepository>();
            await builder.Build().RunAsync();
        }
    }
}
