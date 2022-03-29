using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using PatikaBookStoreWebapi.DbOperations;
using PatikaBookStoreWebapi.Middlewares;
using PatikaBookStoreWebapi.Services;

namespace PatikaBookStoreWebapi
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
             //jwt semasını verdik bos sek,lde aut.
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(opt=>
            {
                opt.TokenValidationParameters=new TokenValidationParameters
                {
                     ValidateAudience=true,  //kimler ulaşsın
                     ValidateIssuer=true,   
                     ValidateLifetime=true,
                     ValidateIssuerSigningKey=true,
                     ValidIssuer=Configuration["Token:Issuer"],
                     ValidAudience=Configuration["Token:Audience"],
                     IssuerSigningKey=new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Token:SecurityKey"])),
                     ClockSkew=TimeSpan.Zero  //token üreten ve kullanacak olan time da aynı anda sonlanması için. Token bizim belirlediğimiz sürede calıscak.
                };

            });
          
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "PatikaBookStoreWebapi", Version = "v1" });
            });
           
            services.AddDbContext<BookStoreDbContext>(options=>options.UseInMemoryDatabase(databaseName:"BookStore"));
            services.AddScoped<IBookStoreDbContext>(provider=>provider.GetService<BookStoreDbContext>());// scoped requestte her seferinde üretir.
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddSingleton<ILoggerServices, DbLogger>();//prog. build olunca Calıssın addsingleton
            //hatalı olan seyi tek bir yerde gosteriyor error mesajlarını tek bir yerde toplayıp daha kolay düzeltme sağlandı. Dbloggera implememnt etti
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "PatikaBookStoreWebapi v1"));
            }
             app.UseAuthentication();//servislerde bu sıra onemli once authentication olmalı
            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseCustomExceptionMiddle();//middleware

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
