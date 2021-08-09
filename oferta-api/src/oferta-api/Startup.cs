using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Authentication.Certificate;
using oferta_infra;
using oferta_domain.Interfaces;
using oferta_infra.Repositories;
using oferta_api.Configurations;
using Microsoft.OpenApi.Models;
using oferta_domain.Interfaces.Repositories;
using oferta_domain.Services;

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
            services.AddControllers();
            services.AddEntityFrameworkSqlite().AddDbContext<DataBaseContext>();

            services.AddCors(options =>
            {
                options.AddPolicy(name: "MyAllowSpecificOrigin",
                builder => {
                    builder.AllowAnyOrigin();
                    builder.AllowAnyHeader();
                    builder.AllowAnyMethod();
                });
            });

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "API Oferta WeChip", Version = "v1" });

				OpenApiSecurityScheme securityDefinition = new OpenApiSecurityScheme()
				{
					Name = "Bearer",
					BearerFormat = "JWT",
					Scheme = "bearer",
					Description = "Specify the authorization token.",
					In = ParameterLocation.Header,
					Type = SecuritySchemeType.Http,
				};
				c.AddSecurityDefinition("jwt_auth", securityDefinition);

				OpenApiSecurityScheme securityScheme = new OpenApiSecurityScheme()
				{
					Reference = new OpenApiReference()
					{
						Id = "jwt_auth",
						Type = ReferenceType.SecurityScheme
					}
				};
				OpenApiSecurityRequirement securityRequirements = new OpenApiSecurityRequirement()
				{
					{securityScheme, new string[] { }},
				};
				c.AddSecurityRequirement(securityRequirements);
            });

            services.AddScoped<IRepositoryClientes, RepositoryClientes>();
            services.AddScoped<IRepositoryProdutos, RepositoryProdutos>();
            services.AddScoped<IRepositoryVendas, RepositoryVendas>();
            services.AddScoped<IRepositoryUsuario, RepositoryUsuario>();
            services.AddScoped<IRepositoryEnderecos, RepositoryEndereco>();
            services.AddScoped<IServiceClientes, ClienteService>();

            services.ConfigServiceAuthentication(Configuration);
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

            app.UseCors("MyAllowSpecificOrigin");

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
