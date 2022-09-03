using CORE.Common.Intefaces;
using CORE.Common.Mappers;
using CORE.DAL.Context;
using CORE.DAL.Interfaces;
using CORE.DAL.Repositories;
using CORE.Dto.Dto;
using CORE.Dto.Requests;
using CORE.Dto.Responses;
using Customer.BAL.Interfaces;
using Customer.BAL.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using customer = CORE.DAL.Models.Customer;
namespace Customer.WebApi
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
            services.AddScoped<ICustomerAppService, CustomerAppService>();
            services.AddScoped<ICustomersRepository, CustomerRespository>();
            services.AddScoped<IModelMapper<customer, CustomerDto>, CustomerMapper>();
            services.AddScoped<IModelMapper<customer, CustomerRequestDto>, CustomerRequestMapper>();

            services.AddDbContext<customersContext>(options =>
            {
                options.UseNpgsql(Configuration.GetConnectionString("CustomerConnectionString"));
            });

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Customer.WebApi", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            //if (env.IsDevelopment())
            //{
            //    app.UseDeveloperExceptionPage();

            //}
            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Customer.WebApi v1"));

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
