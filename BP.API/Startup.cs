using System.Text;
using BP.ApiRepositories;
using BP.ApiRepositories.Interfaces;
using BP.Converters;
using BP.Entities;
using BP.EntityRepositories;
using BP.Repositories;
using BP.StoredProcedures;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using BP.Services;

namespace BP.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            AddCustomerServices(services);
            AddUserIdentityServices(services);
            AddOtherServices(services);
        }

        private void AddOtherServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddTransient<CustomLogger>();
            services.AddDbContext<BPContext>(options => options.UseSqlServer(Configuration.GetConnectionString("BPDatabase")), ServiceLifetime.Transient);
            services.AddTransient(serviceProvider =>
            {
                return new DataSettings(Configuration.GetConnectionString("BPDatabase"));
            });
            services.AddTransient(serviceProvider =>
            {
                return new BusinessSettings(
                    Configuration.GetValue<string>("Security:PrivateEncryptionKey"),
                    Configuration.GetValue<string>("Security:PublicEncryptionKey")
                    );
            });
            services.AddTransient<PasswordService>();
        }

        private void AddUserIdentityServices(IServiceCollection services)
        {
            services.AddTransient<IApiUserIdentityRepository, ApiUserIdentityRepository>();
            services.AddTransient<IUserIdentityRepository, UserIdentityRepository>();
            services.AddTransient<UserIdentitySP>();
            services.AddTransient<UserIdentityDTOConverter>();
            services.AddTransient<UserIdentityConverter>();
        }

        private void AddCustomerServices(IServiceCollection services)
        {
            services.AddTransient<IApiCustomerRepository, ApiCustomerRepository>();
            services.AddTransient<ICustomerRepository, CustomerRepository>();
            services.AddTransient<CustomerSP>();
            services.AddTransient<CustomerDTOConverter>();
            services.AddTransient<CustomerConverter>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
