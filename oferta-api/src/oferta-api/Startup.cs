using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Authentication.Certificate;
using oferta_infra;
using oferta_domain.Interfaces;
using oferta_infra.Repositories;

namespace oferta_api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddAuthentication(
                CertificateAuthenticationDefaults.AuthenticationScheme)
                .AddCertificate();
            services.AddControllers();
            services.AddEntityFrameworkSqlite().AddDbContext<DataBaseContext>();

            services.AddSwaggerGen();

            services.AddScoped<IRepositoryClientes, RepositoryClientes>();
            services.AddScoped<IRepositoryProdutos, RepositoryProdutos>();
            services.AddScoped<IRepositoryVendas, RepositoryVendas>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseAuthentication();
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "API Oferta WeChip v1"));
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
