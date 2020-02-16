using ApexPartyTracker.Common.Repositories;
using ApexPartyTracker.Repositories;
using ApexPartyTracker.Services;
using ApexPartyTracker.Services.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.WindowsAzure.Storage;

namespace ApexLobbyTracker
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
            services.AddControllers();
            services.AddCors(options =>
            {
                options.AddDefaultPolicy(
                    builder =>
                    {
                        builder.WithOrigins("http://localhost:3000")
                        .AllowAnyOrigin()
                        .AllowAnyHeader()
                        .AllowAnyMethod();
                    });
            });
            services.AddHttpContextAccessor();
            services.AddTransient<IPartyService, PartyService>();
            services.AddTransient<IValidationService, ValidationService>();
            services.AddTransient(serviceCollection =>
            {
                var storageAccount = serviceCollection.GetRequiredService<CloudStorageAccount>();
                return storageAccount.CreateCloudTableClient();
            });
            services.AddTransient<IGoogleVisionApiRepository, GoogleVisionApiRepository>();
            services.AddTransient<IPartyRepository, PartyRepository>();
            services.AddScoped(serviceCollection =>
            {
                var connectionString = Configuration.GetConnectionString("StorageAccount");
                return CloudStorageAccount.Parse(connectionString);
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseCors();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
