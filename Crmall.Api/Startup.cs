using Crmall.Domain.Contracts.Handler;
using Crmall.Domain.Contracts.Repository;
using Crmall.Infra.Data;
using Crmall.Infra.Data.Repositories;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Pomelo.EntityFrameworkCore.MySql.Storage;
using System;
using RestSharp;
using Crmall.Infra.ViaCep;

namespace Crmall.Api
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

            //services.AddDbContext<ClienteDataContext>(opt => opt.UseInMemoryDatabase("Crmall"));
            services.AddDbContext<ClienteDataContext>(opt => opt.UseMySql("server=127.0.0.1;database=Crmall;user=root;password=qwer1234#"));

            services.AddTransient<IClienteRepository, ClienteRepository>();
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddTransient<ClienteHandler, ClienteHandler>();

            //Infra.ViaCep
            services.AddTransient<IRestClient, RestClient>();
            services.AddTransient<IRestRequest, RestRequest>();
            services.AddTransient<BuscadorDeCep, BuscadorDeCep>();
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

            app.UseCors(x => x.AllowAnyOrigin()
                              .AllowAnyMethod()
                              .AllowAnyHeader());

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
