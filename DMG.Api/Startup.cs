﻿using System.Collections.Generic;
using DMG.Business.Dtos;
using DMG.Business.Mappers;
using DMG.Business.Services;
using DMG.DatabaseContext;
using DMG.DatabaseContext.Repositories;
using DMG.Models;
using FileHelpers;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Rewrite.Internal.IISUrlRewrite;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;

namespace DMG.Api
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
            services.AddDbContext<DataContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            services.AddMvc();
            services.AddCors();

            services.AddScoped<ISettlementService, SettlementService>();
            services.AddTransient<ISettlementCalculator, SettlementCalculator>();

            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IMapper<User, UserDto>, UserMapper>();
            services.AddScoped<IMapper<CreateUserDto, User>, CreateUserDtoMapper>();

            services.AddScoped<IBillService, BillService>();
            services.AddScoped<IBillRepository, BillRepository>();
            services.AddScoped<IMapper<Bill, BillDto>, BillMapper>();
            services.AddScoped<IMapper<CreateBillDto, Bill>, CreateBillDtoMapper>();

            services.AddScoped<IMapper<IEnumerable<ParseModel>, User>, ParseModelMapper>();
            services.AddScoped<IParser, Parser>();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "DMG API", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseCors(builder => builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());
            //if (env.IsDevelopment())
            //{
            //    app.UseDeveloperExceptionPage();
            //}

            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.), specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "DMG API V1");
            });


            app.UseMvc();
        }
    }
}
