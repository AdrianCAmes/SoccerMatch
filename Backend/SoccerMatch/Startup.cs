﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Repository;
using Repository.dbcontext;
using Repository.Implementacion;
using Service;
using Service.Implementacion;

namespace SoccerMatch
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
            services.AddDbContext<ApplicationDbContext>(options =>
           options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddTransient<IUsuarioRepository, UsuarioRepository>();
            services.AddTransient<IUsuarioService, UsuarioService>();
            services.AddTransient<IEquipoRepository, EquipoRepository>();
            services.AddTransient<IEquipoService, EquipoService>();
            services.AddTransient<IAlquilerRepository, AlquilerRepository>();
            services.AddTransient<IAlquilerService, AlquilerService>();
            services.AddTransient<IJugadorRepository,JugadorRepository>();
            services.AddTransient<IJugadorService,JugadorService>();
            services.AddTransient<IDistritoRepository, DistritoRepository>();
            services.AddTransient<IDistritoService, DistritoService>();
            services.AddTransient<IParticipanteRepository, ParticipanteRepository>();
            services.AddTransient<IParticipanteService, ParticipanteService>();
            services.AddTransient<ICanchaRepository, CanchaRepository>();
            services.AddTransient<ICanchaService, CanchaService>();
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            services.AddCors(options =>
            {
                options.AddPolicy("Todos",
                builder => builder.WithOrigins("*").WithHeaders("*").WithMethods("*"));
            });
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
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseCors("Todos");
            app.UseMvc();
        }
    }
}
