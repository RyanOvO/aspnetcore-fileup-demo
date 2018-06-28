﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.PlatformAbstractions;
using Swashbuckle.AspNetCore.Swagger;


namespace SaleService
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
           services.AddMvc();
           
            services.AddSwaggerGen(option =>
            {
                option.SwaggerDoc("v1", new Info
                {
                    Version = "v1",
                    Title = "SaleService接口文档",
                    Description = "RESTful API for SaleService.",
                    TermsOfService = "None",
                    Contact = new Contact { Name = "seabluescn", Email = "seabluescn@163.com", Url = "" }
                });

                //Set the comments path for the swagger json and ui.
                var basePath = PlatformServices.Default.Application.ApplicationBasePath;
                var xmlPath = Path.Combine(basePath, "SaleService.xml");
                option.IncludeXmlComments(xmlPath);
            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvcWithDefaultRoute();

            app.UseSwagger();

            app.UseSwaggerUI(option =>
            {
                option.ShowExtensions();
                option.SwaggerEndpoint("/swagger/v1/swagger.json", "SaleService V1");
            });
        }
    }
}
