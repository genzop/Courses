using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace OdeToFood
{
    public class Startup
    {
        // Registra diferentes servicios al container que luego podran ser injectados 
        public void ConfigureServices(IServiceCollection services)
        {
            // Se registra la interface como un Singleton, es decir que solo va a haber una instancia de su implementacion durante la vida de la aplicacion.
            // Cada vez que alguien requiera un metodo que implemente IGreeter, se le injecta la clase Greeter.
            services.AddSingleton<IGreeter, Greeter>();

            services.AddMvc();
        }

        // Define que componentes van a responder a cada mensaje HTTP que llega
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, IGreeter greeter, ILogger<Startup> logger)
        {
            #region ExceptionPage Middleware
            // Si es ambiente de desarrollo
            if (env.IsDevelopment())
            {
                // Registra un Middleware que intercepta todas las excepciones que ocurran durante la ejecucion del pipeline
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

            app.UseMvcWithDefaultRoute();

            // Escribe en la respuesta un mensaje
            app.Run(async (context) =>
            {
                var greeting = greeter.GetMessageOfTheDay();
                await context.Response.WriteAsync(greeting);
            });
        }
    }
}
