using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using POC_SignalR.Hubs;
using POC_SignalR.Service;

namespace POC_SignalR
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
            services.AddCors();
            services.AddSignalR();
            services.AddControllers();
            services.AddSingleton<IEmployeeService, EmployeeService>();
            services.AddSingleton<IProjectService, ProjectService>();
            services.AddSingleton<LoadDefaultDataService, LoadDefaultDataService>();        
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            
            app.UseCors(options => options
            .WithOrigins("http://localhost:3001", "http://localhost:3002", "null")
            .AllowAnyMethod()
            .AllowAnyHeader()
            .AllowCredentials()
            );

            app.UseSignalR(action => { action.MapHub<HubServer>("/signalrhub"); });
            HubServer.Current = app.ApplicationServices.GetService<IHubContext<HubServer>>();
            app.UseRouting();

            app.UseAuthorization();

            app.ApplicationServices.GetService<LoadDefaultDataService>();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
