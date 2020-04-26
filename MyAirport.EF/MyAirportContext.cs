using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using MyAirport.EF;
using System;
using System.Collections.Generic;
using System.Text;


namespace PC.MyAirport.EF
{
    /// <summary>
    /// Classe appelant les différentes méthodes en lien avec l'aéroport
    /// </summary>
    public class MyAirportContext : DbContext
    {
       //public static readonly ILoggerFactory MyAirportLoggerFactory = LoggerFactory.Create(builder => { builder.AddConsole(); });
        
        /// <summary>
        /// Référence à MyAirportContext
        /// </summary>
        /// <param name="options"></param>
        public MyAirportContext(DbContextOptions<MyAirportContext> options) : base(options) { }

        /// <summary>
        /// Référence à la classe bagage
        /// </summary>
        public DbSet<Vol>? Vols { get; set; }

        /// <summary>
        /// Référence à la classe bagage
        /// </summary>
        public DbSet<Bagage>? Bagages { get; set; }

       /* protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                @"Server=(localdb)\mssqllocaldb;Database=MyAirportContext;Integrated Security=True");
            //optionsBuilder.UseLoggerFactory(MyAirportLoggerFactory);

        }*/

    }

}
