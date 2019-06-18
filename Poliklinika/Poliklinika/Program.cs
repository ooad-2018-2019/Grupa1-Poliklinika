using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Poliklinika.Models;


namespace Poliklinika
{
    public class Program
    {
        public static void Main(string[] args)
        {
            /*
             * Kod za citanje i pristup bazi
             * try
            {
                SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
                builder.DataSource = "ehlimanatest.database.windows.net";
                builder.UserID = "Ehlimana";
                builder.Password = "Ooad2019";
                builder.InitialCatalog = "Database 1";

                using (SqlConnection connection = new SqlConnection(builder.ConnectionString))
                {
                    Console.WriteLine("\nQuery data example:");
                    Console.WriteLine("=========================================\n");

                    connection.Open();
                    StringBuilder sb = new StringBuilder();
                    sb.Append("SELECT TOP 20 pc.ime as ImeOsobe, pc.prezime as PrezimeOsobe ");
                    sb.Append("FROM dbo.Poliklinika_Osoba pc; ");
                   
                   String sql = sb.ToString();

                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Console.WriteLine("{0} {1}", reader.GetString(0), reader.GetString(1));
                            }
                        }
                    }
                }
            }
            catch (SqlException e)
            {
                Console.WriteLine("Nesto nije uredu sa bazom!");
                Console.WriteLine(e.ToString());
            }
            Console.ReadLine(); */
            
            Administrator.Instance.dodajPacijenta(new Login(new Pacijent("Emir", "Pita", "epita1@etf.unsa.ba", "Sarajevo", new DateTime(1998, 04, 30)), "epita1", "epita"));

            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
        
    }
}
