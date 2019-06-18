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
      
        const String maxIdPacijentaQuery = "SELECT MAX(id) FROM dbo.Poliklinika_Pacijent;";
        const String maxIdOsobeQuery= "SELECT MAX(id) FROM dbo.Poliklinika_Osoba;";
        const String maxIdLoginQuery = "SELECT MAX(id) FROM dbo.Poliklinika_Login;";

        private static Administrator instance;

        private Administrator() { }

        public static Administrator Instance
            {
            get
                {
                if (instance == null)
                    {
                    instance = new Administrator();
                    }
                return instance;
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

SqlCommand cmdZaTabeluOsoba= new SqlCommand(@"INSERT INTO dbo.Poliklinika_Osoba (id,ime, prezime, DatumRodjenja, email, MjestoRodjenja)
              VALUES (@id, @ime, @prezime, @DatumRodjenja, @email, @MjestoRodjenja )", connection);
                    int maxId = vratiNajveciID(maxIdPacijentaQuery);
cmdZaTabeluOsoba.Parameters.Add(new SqlParameter("id", maxId));
cmdZaTabeluOsoba.Parameters.Add(new SqlParameter("ime", login.osoba.ime));
cmdZaTabeluOsoba.Parameters.Add(new SqlParameter("prezime", login.osoba.prezime));
cmdZaTabeluOsoba.Parameters.Add(new SqlParameter("DatumRodjenja", login.osoba.datumRodjenja));
cmdZaTabeluOsoba.Parameters.Add(new SqlParameter("email", login.osoba.email));
cmdZaTabeluOsoba.Parameters.Add(new SqlParameter("MjestoRodjenja", login.osoba.mjestoRodjenja));
cmdZaTabeluOsoba.ExecuteNonQuery();

                    //Dodajem pacijenta u tabelu pacijenata
                SqlCommand cmdZaTabeluPacijent = new SqlCommand(@"INSERT INTO dbo.Poliklinika_Pacijent (id,idOsobeFK)
              VALUES (@id, @idOsobeFK )", connection);


                 cmdZaTabeluPacijent.Parameters.Add(new SqlParameter("id", vratiNajveciID(maxIdPacijentaQuery) ));
                 cmdZaTabeluPacijent.Parameters.Add(new SqlParameter("idOsobeFK", maxId));
                    cmdZaTabeluPacijent.ExecuteNonQuery();
                    //Dodajem login podatke u tabelu login
                    SqlCommand cmdZaTabeluLogin = new SqlCommand(@"INSERT INTO dbo.Poliklinika_Login (id,username, password, idOsobeFK)
              VALUES (@id, @username, @password, @idOsobeFK )", connection);
                    cmdZaTabeluLogin.Parameters.Add(new SqlParameter("id", vratiNajveciID(maxIdLoginQuery)));
                    cmdZaTabeluLogin.Parameters.Add(new SqlParameter("idOsobeFK", maxId));
                    cmdZaTabeluLogin.Parameters.Add(new SqlParameter("username", login.username));
                    cmdZaTabeluLogin.Parameters.Add(new SqlParameter("password", login.password));
                    cmdZaTabeluLogin.ExecuteNonQuery();

                    connection.Close();
                    Console.WriteLine("Uspjesno dodan pacijent!");



                    }
}
catch (SqlException e)
{
throw new Exception("Greska prilikom dobavljanja MAX id-a: " + e);
}

}


        public void dodajLogin (String username, String password, Int32 idOsobe) {


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
Console.WriteLine(query);

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
                            int povratnaVrijednost = 0;
                            Console.WriteLine(reader.FieldCount);
        if (reader.FieldCount == 0) return 0;
        reader.Read();

                     try
                                {
                                 povratnaVrijednost = reader.GetInt32(0);
                                
                                }
                            catch (Exception)
                                {
                                return 0;
                                }
        return povratnaVrijednost;
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
