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
using System.Text;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using System;

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
            AddDriverServices(services);
            AddUserIdentityServices(services);
            AddUserServices(services);
            AddOtherServices(services);
            ConfigureAuthentication(services);
        }

        private void AddUserServices(IServiceCollection services)
        {
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<UserConverter>();
            services.AddTransient<UserSP>();
        }

        private void ConfigureAuthentication(IServiceCollection services)
        {
            var key = Encoding.ASCII.GetBytes(Configuration.GetValue<string>("Security:JwtSecret"));
            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });

            services.AddCors(options =>
            {
                options.AddDefaultPolicy(
                    builder =>
                    {
                        builder.WithOrigins("https://localhost:44377")
                        .AllowAnyMethod()
                        .AllowAnyHeader();

                    });
            });
        }

        private void AddDriverServices(IServiceCollection services)
        {
            services.AddTransient<IApiDriverRepository, ApiDriverRepository>();
            services.AddTransient<IDriverRepository, DriverRepository>();
            services.AddTransient<DriverSP>();
            services.AddTransient<DriverDTOConverter>();
            services.AddTransient<DriverConverter>();
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
                    Configuration.GetValue<string>("Security:PublicEncryptionKey"),
                    Configuration.GetValue<string>("Security:JwtSecret"),
                    Configuration.GetValue<string>("Security:ApiPassword")
                    );
            });
            services.AddTransient<DecryptionService>();
            services.AddTransient<AuthenticationService>();
            services.AddTransient<ClaimsService>();
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
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseCors();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
