using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dominio.InterfacesRepositorio;
using Dominio.EntidadesVivero;
using LogicaDeAplicacion;
using Repositorios;

namespace Vivero
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
            services.AddControllersWithViews();

            //para uso de sesiones
            services.AddSession();

            //servicios de repositorios
            services.AddScoped<IRepositorioTipoPlanta, RepositorioTipoPlantaADO>();
            services.AddScoped<IRepositorioUsuario, RepositorioUsuarioADO>();
            services.AddScoped<IRepositorioPlantas, RepositorioPlantaADO>();
            services.AddScoped<IRepositorioIluminacion, RepositorioIluminacionADO>();

            //servicios de manejadoras  
            services.AddScoped<IManejadorTipoPlantas, ManejadorTipoPlantas>();
            services.AddScoped<IManejadorUsuario, ManejadorUsuario>();
            services.AddScoped<IManejadorPlanta, ManejadorPlanta>();
            services.AddScoped<IManejadorIluminacion, ManejadorIluminacion>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            //para uso de sesiones
            app.UseSession();
            app.UseHttpsRedirection();

            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
