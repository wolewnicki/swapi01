using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using swapi.Services;
using SolrNet;
using swapi.Models;

namespace swapi
{
    public class LaunchApp
    {
        //public void SolrStart()
        //{
        //    Startup.Init<Person>("https://solr:8983/solr/mycoll");
        //} This is the Old way to Init Solr
        public LaunchApp(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddSingleton<ISwapiService, SwapiService>();
            services.AddSingleton<IGetRandomPerson, GetRandomPerson>();
            services.AddSingleton<IGetRandomPlanet, GetRandomPlanet>();
            services.AddSingleton<IPlanetService, PlanetService>();
            services.AddTransient<SolrInjector>();
            services.AddSolrNet("http://solr:8983/solr/mycoll");
            services.AddSolrNet<Person>("http://solr:8983/solr/mycoll");
            services.AddSolrNet<RootObject>("http://solr:8983/solr/mycoll");
            services.AddSolrNet<PersonModel>("http://solr:8983/solr/mycoll");
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
