using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Z_BandAPI.DbContexts;
using Z_BandAPI.Services.IRepository;
using Z_BandAPI.Services.Repository;

namespace Z_BandAPI
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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            // added
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            // added
            services.AddScoped<IBandAlbumRepository, BandAlbumRepository>();


            services.AddDbContext<BandAlbumDbContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("DBDefaultConnection"));
            });
            //
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // for production exceptionhandler
                app.UseExceptionHandler(appBuilder =>
                {
                    appBuilder.Run(async x =>
                    {
                        x.Response.StatusCode = 500;
                        await x.Response.WriteAsync("Something went horribly wrong, try again later");
                    });
                });
            }

            app.UseMvc();
        }
    }
}
