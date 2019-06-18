using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poliklinika.Models
{
    public class Administrator : IBazaLijekova, IBazaPoliklinike
      
    {
      
        const String maxIdPacijentaQuery = "SELECT MAX(id) FROM dbo.Poliklinika_Pacijent";
        const String maxIdOsobeQuery= "SELECT MAX(id) FROM dbo.Poliklinika_Osoba";

        private static Administrator instance = null;
        private static readonly object padlock = new object();

        Administrator()
        {
        }

        public static Administrator Instance
        {
            get
            {
                lock (padlock)
                {
                    if (instance == null)
                    {
                        instance = new Administrator();
                    }
                    return instance;
                }
            }
        }




        public void azurirajLijek(Lijek lijek)
        {
            throw new NotImplementedException();
        }

        public Lijek dodajLijek()
        {

            throw new NotImplementedException();
        }

       
    

        public void dodajPacijenta( Login login)
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

/*
 * SELECT TOP (1000) [id]
,[ime]
,[prezime]
,[DatumRodjenja]
,[email]
,[MjestoRodjenja]
FROM [dbo].[Poliklinika_Osoba] */
SqlCommand cmd = new SqlCommand(@"INSERT INTO dbo.Poliklinika_Osoba (id,ime, prezime, DatumRodjenja, email, MjestoRodjenja)
              VALUES (@id, @ime, @prezime, @DatumRodjenja, @email, @MjestoRodjenja )", connection);
cmd.Parameters.Add(new SqlParameter("id", vratiNajveciID(maxIdPacijentaQuery)));
cmd.Parameters.Add(new SqlParameter("ime", login.osoba.ime));
cmd.Parameters.Add(new SqlParameter("prezime", login.osoba.prezime));
cmd.Parameters.Add(new SqlParameter("DatumRodjenja", login.osoba.datumRodjenja));
cmd.Parameters.Add(new SqlParameter("email", login.osoba.email));
cmd.Parameters.Add(new SqlParameter("MjestoRodjenja", login.osoba.mjestoRodjenja));

                    
                    
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



public void ukloniPacijenta(Login osoba)
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
