using DynamicForm.BusinessLogic.Interfaces;
using DynamicForm.BusinessLogic.Services;
using DynamicForm.DataAccess;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace DynamicForm.Web
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        
        public Startup(IWebHostEnvironment environment)
        {
            var builder = new ConfigurationBuilder().SetBasePath(environment.ContentRootPath)
                                                    .AddJsonFile($"appsettings.json", true, true)
                                                    .AddJsonFile($"appsettings.{environment.EnvironmentName}.json", true, true)
                                                    .AddEnvironmentVariables();

            Configuration = builder.Build();
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddCors();
            services.AddScoped<ISubmissionService, SubmissionService>();
            services.AddSingleton<ISubmissionRepository, SubmissionRepository>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }


            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors(builder => builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
