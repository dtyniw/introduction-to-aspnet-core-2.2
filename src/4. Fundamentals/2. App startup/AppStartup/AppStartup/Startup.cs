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

namespace AppStartup
{
    /// <summary>
    /// ASP.NET Core apps use a Startup class, which is named Startup by convention. The Startup class:
    ///
    /// <list type="bullet">
    /// <item>Optionally includes a ConfigureServices method to configure the app's services. A service is a reusable component that provides app functionality. Services are configured—also described as registered—in ConfigureServices and consumed across the app via dependency injection (DI) or ApplicationServices.</item>
    /// <item>Includes a Configure method to create the app's request processing pipeline.</item>
    /// </list>
    /// </summary>
    public class Startup
    {
        private readonly IHostingEnvironment _env;
        private readonly IConfiguration _config;
        private readonly ILoggerFactory _loggerFactory;

        public Startup(IHostingEnvironment env, IConfiguration config,
            ILoggerFactory loggerFactory)
        {
            _env = env;
            _config = config;
            _loggerFactory = loggerFactory;
        }

        /// <summary>
        /// The ConfigureServices method is:
        /// <list type="bullet">
        /// <item>Optional.</item>
        /// <item>Called by the host before the Configure method to configure the app's services.</item>
        /// <item>Where configuration options are set by convention.</item>
        /// </list>
        /// The typical pattern is to call all the Add{Service}
        /// methods and then call all of the services.Configure { Service }
        /// methods.For example, see Configure Identity services.
        /// </summary>
        public void ConfigureServices(IServiceCollection services)
        {
            var logger = _loggerFactory.CreateLogger<Startup>();

            if (_env.IsDevelopment())
            {
                // Development service configuration

                logger.LogInformation("Development environment");
            }
            else
            {
                // Non-development service configuration

                logger.LogInformation($"Environment: {_env.EnvironmentName}");
            }

            services.AddMvc();

            // Configuration is available during startup.
            // Examples:
            //   _config["key"]
            //   _config["subsection:suboption1"]
        }

        /// <summary>
        /// The Configure method is used to specify how the app responds to HTTP requests.
        /// The request pipeline is configured by adding middleware components to an IApplicationBuilder instance.
        /// IApplicationBuilder is available to the Configure method, but it isn't registered in the service container.
        /// Hosting creates an IApplicationBuilder and passes it directly to Configure.
        /// </summary>
        /// <param name="app"></param>
        /// <param name="env"></param>
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseMvc();
        }
    }
}
