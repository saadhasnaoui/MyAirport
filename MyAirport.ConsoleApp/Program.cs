using PC.MyAirport.EF;
using MyAirport.EF;
using Microsoft.EntityFrameworkCore;
using System.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;

namespace PC.MyAirport.ConsoleApp
{
    class Program
    {
        public static readonly ILoggerFactory MyAirportLoggerFactory = LoggerFactory.Create(builder => { builder.AddConsole(); });
        static void Main(string[] args)
        {

            var optionsBuilder = new DbContextOptionsBuilder<MyAirportContext>();

            optionsBuilder.UseLoggerFactory(MyAirportLoggerFactory);
            optionsBuilder.UseSqlServer(ConfigurationManager.ConnectionStrings["MyAirportContext"].ConnectionString);

            


            System.Console.WriteLine("MyAirport project bonjour!!");
            using (var db = new MyAirportContext(optionsBuilder.Options))
            //using (var db = new MyAirportContext())
            {
                // Create
                Console.WriteLine("Création du vol LH1232");
                Vol v1 = new Vol("LH","1232", Convert.ToDateTime("14/01/2020 16:45"))
                {
                    Des = "BKK",
                    Imm = "RZ62",
                    Pkg = "R52",
                    Pax = 238
                };
                db.Add(v1);
                db.SaveChanges();

                Console.WriteLine("Creation vol SQ333");
                Vol v2 = new Vol("SK", "333", Convert.ToDateTime("14/01/2020 18:20"))
                {
                    Des = "CDG",
                    Imm = "TG43",
                    Pkg = "R51",
                    Pax = 423
                };
                db.Add(v2);

                Console.WriteLine("creation du bagage 012387364501");
                Bagage b1 = new Bagage("012387364501", Convert.ToDateTime("14/01/2020 12:52"))
                {
                    Classe = "Y",
                    Destination = "BEG",
                };
                db.Add(b1);

                db.SaveChanges();
                Console.ReadLine();

                // Read
                Console.WriteLine("Voici la liste des vols disponibles");
                var vol = db.Vols
                    .OrderBy(v => v.Cie);
                foreach (var v in vol)
                {
                    Console.WriteLine($"Le vol {v.Cie}{v.Lig} N° {v.VolId} a destination de {v.Des} part à {v.Dhc} heure");
                }
                Console.ReadLine();

                


                // Update
                Console.WriteLine($"Le bagage {b1.BagageId} est modifié pour être rattaché au vol {v1.VolId} => {v1.Cie}{v1.Lig}");
                b1.VolId = v1.VolId;
                db.SaveChanges();
                Console.ReadLine();

                Console.WriteLine($"Il y a {v1.Bagages.Count()}  bagages sur le vol {v1.VolId}");

                // Delete vol et bagages du vol
                Console.WriteLine($"Suppression du vol {v1.VolId} => {v1.Cie}{v1.Lig}");
                db.Remove(v1);
                db.SaveChanges();
                Console.ReadLine();


            }
        }
    }
}
