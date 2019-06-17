using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poliklinika.Models
{
    public class Administrator : IBazaLijekova, IBazaPoliklinike
        ///amra je tu tesriram pushanje
    {
        const String maxIdPacijentaQuery = "SELECT MAX(id) FROM dbo.Poliklinika_Pacijent";
        const String maxIdOsobeQuery= "SELECT MAX(id) FROM dbo.Poliklinika_Osoba";
        public void azurirajLijek(Lijek lijek)
        {
            throw new NotImplementedException();
        }

        public Lijek dodajLijek()
        {

            throw new NotImplementedException();
        }

       
    

        public void dodajPacijenta(Pacijent osoba)
        {
          //TODO...

            try
            {
                SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
                builder.DataSource = "ehlimanatest.database.windows.net";
                builder.UserID = "Ehlimana";
                builder.Password = "Ooad2019";
                builder.InitialCatalog = "Database 1";


                using (SqlConnection connection = new SqlConnection(builder.ConnectionString))
                {
                  
                    connection.Open();
                    StringBuilder sb = new StringBuilder();
                    // sb.Append(query);
                    // sb.Append("SELECT TOP 20 pc.ime as ImeOsobe, pc.prezime as PrezimeOsobe ");
                    // sb.Append("FROM dbo.Poliklinika_Osoba pc; ");
                    SqlCommand cmd = new SqlCommand(@"INSERT INTO dbo.Poliklinika_Osoba (id, Nominativo)
                                  VALUES (@Id, @Nominativo)", connection);
                    cmd.Parameters.Add(new SqlParameter("Id", vratiNajveciID(maxIdPacijentaQuery)));
                    cmd.Parameters.Add(new SqlParameter("Nominativo", "MARIO ROSSI"));
                    cmd.ExecuteNonQuery();

                }
            }
            catch (SqlException e)
            {
                throw new Exception("Greska prilikom dobavljanja MAX id-a: " + e);
            }

        }

        public void dodajZaposlenika()
        {
            throw new NotImplementedException();
        }

        public void dodijeliLijekTerapiji(Lijek lijek)
        {
            throw new NotImplementedException();
        }

        public void izlistajSvePacijente()
        {
            throw new NotImplementedException();
        }

        public void izlistajSvoOsoblje()
        {
            throw new NotImplementedException();
        }

        public void ukloniLijek(Lijek lijek)
        {
            throw new NotImplementedException();
        }

     

        public void ukloniPacijenta(Pacijent osoba)
        {
            throw new NotImplementedException();
        }

        public void ukloniZaposlenika()
        {
            throw new NotImplementedException();
        }

        public Int32 vratiNajveciID(String query)
        {
           
            //Da bi se ostvarilo dodavanje novog elementa u bazu, moram znat najveci id
            //da bi ga mogao inkrementirati
            try
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
                    sb.Append(query);
                   // sb.Append("SELECT TOP 20 pc.ime as ImeOsobe, pc.prezime as PrezimeOsobe ");
                   // sb.Append("FROM dbo.Poliklinika_Osoba pc; ");

                    String sql = sb.ToString();

                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            //Ukoliko je tabela prazna
                            if (reader.FieldCount == 0) return 0;
                            reader.Read();
                            return reader.GetInt32(0);
                         }
                    }
                }
            }
            catch (SqlException e)
            {
                throw new Exception("Greska prilikom dobavljanja MAX id-a: " + e);
            }
           }
    }
}
