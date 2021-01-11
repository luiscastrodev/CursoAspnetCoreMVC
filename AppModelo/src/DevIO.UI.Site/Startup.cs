using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DevIO.UI.Site.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace DevIO.UI.Site
{
    public class Startup
    {

        public IConfiguration Configuration { get; }


        public Startup(IConfiguration configuration)
        {
            this.Configuration = Configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {

            //configuracao da pasta area quando alterou o nome para modulos
            services.Configure<RazorViewEngineOptions>(options =>
            {
                options.AreaViewLocationFormats.Clear();
                options.AreaViewLocationFormats.Add("/Modulos/{2}/Views/{1}/{0}.cshtml");
                options.AreaViewLocationFormats.Add("/Modulos/{2}/Views/Shared/{0}.cshtml");
                options.AreaViewLocationFormats.Add("/Views/Shared/{0}.cshtml");
            });


            //configuracao entity framework
            services.AddDbContext<MeuDBContext>(
                  options => options.UseSqlServer(this.Configuration.GetConnectionString("MeuDBContext"))) ;

            //adiciona mvc e seta versao 
            services.AddMvc().SetCompatibilityVersion(Microsoft.AspNetCore.Mvc.CompatibilityVersion.Version_3_0);

            //adicionando Injecao denpendencia criada
            services.AddTransient<IPedidoRepository, PedidoRepository>();

            //Injecao DP
            //Transiente Obter uma nova instancia do objeto a cada solicitacao

            //Scoped Reutiliza a mesma instancia do objeto durante todo o request (web)

            //Singleton utiliza a mesma instacnia para toda aplicacao (cuidado)
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }


            //usar arquivos staticos por exemplo jquery , css js etc...
            app.UseStaticFiles();

            app.UseRouting();

            //configura rota default mvc
            app.UseEndpoints(routes =>
            {
                routes.MapControllerRoute(
                     name: "default",
                     pattern: "{controller=Home}/{action=Index}/{id?}");

                //configurando uma area
                /*routes.MapControllerRoute(
                  name: "areas",
                  pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
                  );*/

                routes.MapAreaControllerRoute(
                    name: "AreaProdutos",
                    areaName: "Produtos",
                    "{controller=Cadastro}/{action=Index}/{id?}"
                    );
                routes.MapAreaControllerRoute(
                   name: "AreaVendas",
                   areaName: "Pedidos",
                   "{controller=Pedidos}/{action=Index}/{id?}"
                   );
            });


        }
    }
}
