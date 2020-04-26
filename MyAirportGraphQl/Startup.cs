using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PC.MyAirport.EF;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using MyAirportGraphQl.GraphQLType;

namespace MyAirportGraphQl
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<AirportQuery>();
            services.AddSingleton<AirportSchema>();
            services.AddSingleton<BagageType>();
            services.AddSingleton<VolType>();
            services.AddDbContext<MyAirportContext>(option =>
            option.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=MyAirportContext;Integrated Security=True"));
            services.AddControllers();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseGraphiQLServer(new GraphQL.Server.Ui.GraphiQL.GraphiQLOptions { GraphiQLPath = "/api/graphql"});

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
