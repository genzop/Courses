using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

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
        }

        // Define que componentes van a responder a cada mensaje HTTP que llega
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, IGreeter greeter)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            // Por cada request que llega, escribo en la respuesta un mensaje que contiene el texto "Hello World!"
            app.Run(async (context) =>
            {
                var greeting = greeter.GetMessageOfTheDay();
                await context.Response.WriteAsync(greeting);
            });
        }
    }
}
