using AdminUsers.Context;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AdminUsers.Services;
using AdminUsers.Interfaces;
using AutoMapper;
using AdminUsers.Utilidades;
using AdminUsers.DTOs;


namespace AdminUsers
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
            services.AddDbContext<Contexto>(options => options.UseSqlServer(Configuration.GetConnectionString("ConexionText")));
            services.AddControllers();
            
            
            //---Services---
            services.AddScoped<ICargo, CargoServices>();
            services.AddScoped<IUsuario, UsuarioServices>();
            services.AddScoped<IDepartamento, DepartamentoServices>();


            //Se agregar un Cors para permitir a cualquier origen consultar cualquier metodo HTTP, asi evitamos tener conflicto al consultar de una url disinta (frontend) al backend
            services.AddCors(options =>
            {
                options.AddPolicy("NuevaPolitica", app =>
                {
                    app.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
                });
            });
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "AdminUsers", Version = "v1" });
            });
            //Para realizar el Mapeo de las clases originales a las clases referenciales
            services.AddAutoMapper(typeof(AutoMapperProfile));

        }


        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "AdminUsers v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();
            app.UseCors("NuevaPolitica");
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
