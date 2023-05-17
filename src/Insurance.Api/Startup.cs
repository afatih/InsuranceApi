using Insurance.Api.Middlewares;
using Insurance.Application.Handlers;
using Insurance.Application.Services;
using Insurance.Domain.Interfaces.Handlers;
using Insurance.Domain.Interfaces.Providers;
using Insurance.Domain.Interfaces.Services;
using Insurance.Infrastructure.Providers;
using Insurance.Infrastructure.Storage;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;

namespace Insurance.Api
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

            services.AddScoped<IInsuranceService, InsuranceService>();
            services.AddScoped<ISurchargeService, SurchargeService>();
            services.AddScoped<IProductProvider, ProductProvider>();
            services.AddScoped<IProductTypeProvider, ProductTypeProvider>();
            services.AddSingleton<ISurchargesStorage, SurchargesStorage>();

            services.AddScoped<IInsuranceCalculateHandler, SalesPriceHandler>();
            services.AddScoped<IInsuranceCalculateHandler, ProductTypeMatchHandler>();
            services.AddScoped<IInsuranceCalculateHandler, ProductTypeContainsHandler>();
            services.AddScoped<IInsuranceCalculateHandler, SurchargeHandler>();

            services.AddSwaggerGen();
            services.AddHttpClient("ProductAPI", client => client.BaseAddress = new Uri(Configuration.GetValue<string>("ProductApi")));
            services.AddTransient<ExceptionMiddleware>();

            services.AddLogging(builder =>
            {
                builder.AddConsole();
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();
            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
                options.RoutePrefix = string.Empty;
            });

            app.UseMiddleware<ExceptionMiddleware>();

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