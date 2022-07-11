using AutoMapper;
using Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Rewrite;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Services.Compositions;
using Services.MapperProfile;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1
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
            services.AddMvc(e => e.EnableEndpointRouting = false);
            //services.AddControllers().AddNewtonsoftJson(o => o.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver());
            services.AddDbContext<CoreContext>(options =>
             options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"), o =>
             {
                 o.CommandTimeout(600000);
                 o.EnableRetryOnFailure(5);
             }));

            services.RegisterDependencies();
            RegisterMapper(services);
        }

        private void RegisterMapper(IServiceCollection services)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new AutomapperProfile());
            });
            var mapper = config.CreateMapper();
            services.AddSingleton(mapper);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }


            app.UseHttpsRedirection();
            app.UseFileServer();
            app.UseMvc();

            var option = new RewriteOptions();
            option.AddRedirect("^$", "/");
            app.UseRewriter(option);
        }
    }
}
