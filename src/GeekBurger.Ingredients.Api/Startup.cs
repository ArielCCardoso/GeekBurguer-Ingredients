using AutoMapper;
using GeekBurger.Ingredients.Api.AutoMapper;
using GeekBurger.Ingredients.Api.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.PlatformAbstractions;
using Swashbuckle.AspNetCore.Swagger;
using System.IO;

namespace GeekBurger.Ingredients.Api
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
            services.AddAutoMapper(m => m.AddProfile(new ApplicationProfile()));

            services.AddScoped<MockRepository>();

            string applicationPath = PlatformServices.Default.Application.ApplicationBasePath;
            string applicationName = PlatformServices.Default.Application.ApplicationName;
            string path = Path.Combine(applicationPath, $"{applicationName}.xml");

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "Geek Burger Ingredients API", Version = "v1" });

                c.IncludeXmlComments(path);
            });

            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Geek Burger Ingredients API");
            });

            app.UseCors((c) => c.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());

            app.UseMvc();
        }
    }
}
