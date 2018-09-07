using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using OdeToFood.Services;

namespace OdeToFood
{
    public class Startup
    {
        // Registra diferentes servicios al container que luego podran ser injectados 
        public void ConfigureServices(IServiceCollection services)
        {
            // Registra la interface IGreeter y su implementacion Greeter como un Singleton, es decir que solo va a haber una instancia de su implementacion durante la vida de la aplicacion.            
            services.AddSingleton<IGreeter, Greeter>();

            // Registra la interface IRestaurantData con su implementacion InMemoryRestaurantData como scoped, es decir que va a crear una instancia de ese objeto por request y reutilizar esa instancia en ese request.            
            services.AddScoped<IRestaurantData, InMemoryRestaurantData>();

            // Registra el framework MVC
            services.AddMvc();
        }

        // Define que middlewares van a intervenir en la respuesta a cada mensaje HTTP
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, IGreeter greeter, ILogger<Startup> logger)
        {
            #region ExceptionPage Middleware
            // Si es ambiente de desarrollo
            if (env.IsDevelopment())
            {
                // Intercepta todas las excepciones que ocurran durante la ejecucion del pipeline y lo muestra en una pantalla descriptiva
                app.UseDeveloperExceptionPage();
            }
            #endregion

            #region DefaultFiles Middleware
            // Establece como pagina por defecto a archivos con nombres estandard como index.html
            /* app.UseDefaultFiles(); */
            #endregion

            #region StaticFiles Middleware
            // Permite acceso a los archivos que se encuentran en la carpeta wwwroot
            app.UseStaticFiles();
            #endregion

            #region FilesServer Middleware
            // Cumple con la funcion de DefaultFiles y StaticFiles
            /* app.UseFileServer(); */
            #endregion

            #region Custom Middleware
            // Crea un middleware que utiliza la interface ILogger para escribir logs a la consola
            /*
            app.Use(next =>
            {
                return async context =>
                {
                    logger.LogInformation("Request incoming");

                    // Si la ruta comienza con "/custom"
                    if (context.Request.Path.StartsWithSegments("/custom"))
                    {
                        // Escribe en la respuesta un mensaje
                        await context.Response.WriteAsync("Hit!!");
                        logger.LogInformation("Request handled");
                    }
                    else
                    {
                        // Deja que el request siga por el pipeline
                        await next(context);
                        logger.LogInformation("Request outgoing");
                    }
                };
            });
            */
            #endregion

            #region UseWelcomePage Middleware
            // Agrega el middleware UseWelcomePage al pipeline      
            /*
            app.UseWelcomePage(new WelcomePageOptions
            {
                Path = "/welcome"
            });
            */
            #endregion

            // Configura MVC y las rutas
            app.UseMvc(ConfigureRoutes);

            // Escribe en la respuesta un mensaje
            app.Run(async (context) =>
            {
                var greeting = greeter.GetMessageOfTheDay();
                context.Response.ContentType = "text/plain";
                await context.Response.WriteAsync("Not Found");
            });
        }

        // Configura como se mapearan las rutas de la url a los actions en los controllers
        private void ConfigureRoutes(IRouteBuilder routeBuilder)
        {
            // Ruta por defecto, con Home y Index como controller y action por defecto. El id es opcional.
            routeBuilder.MapRoute("Default", "{controller=Home}/{action=Index}/{id?}");
        }
    }
}
