using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poliklinika.Models
{
    public class MedicinskaSestra : Osoba,IBazaLijekova, IZakazivanjeTermina, IUvidUKarton
    {
        public MedicinskaSestra(string ime, string prezime, string email, string mjestoRodjenja, DateTime datumRodjenja) : base(ime, prezime, email, mjestoRodjenja, datumRodjenja)
            {
            this.Ime = ime;
            this.Prezime = prezime;
            this.Email = email;
            this.MjestoRodjenja = mjestoRodjenja;
            this.DatumRodjenja = datumRodjenja;

            }

        public void azurirajLijek(Lijek lijek)
        {
            throw new NotImplementedException();
        }

        public void dodajLijek(Lijek lijek)
        {
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


                    SqlCommand cmdZaTabeluOsoba = new SqlCommand(@"INSERT INTO dbo.Poliklinika_Osoba (id,nazivLijeka, rok, detalji, kolicina, idTerapija)
                    VALUES (@id, @nazivLijeka, @rok, @detalji, @kolicina, @idTerapija )", connection);
                    int maxId = vratiNajveciID("SELECT MAX(ID) FROM dbo.Poliklinika_Lijek");
                    cmdZaTabeluOsoba.Parameters.Add(new SqlParameter("id", maxId));
                    cmdZaTabeluOsoba.Parameters.Add(new SqlParameter("nazivLijeka", lijek.NazivLijeka));
                    cmdZaTabeluOsoba.Parameters.Add(new SqlParameter("rok", lijek.RokLijeka));
                    cmdZaTabeluOsoba.Parameters.Add(new SqlParameter("detalji", lijek.Detalji));
                    cmdZaTabeluOsoba.Parameters.Add(new SqlParameter("kolicina", lijek.Kolicina));
                    cmdZaTabeluOsoba.Parameters.Add(new SqlParameter("idTerapija", null));


                    cmdZaTabeluOsoba.ExecuteNonQuery();

                    connection.Close();
                



                    }
                }
            catch (SqlException e)
                {
                throw new Exception("Greska prilikom dodavanja medicinske sestre ili doktora : " + e);
                }
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

                            reader.Read();

                            try
                                {
                                povratnaVrijednost = reader.GetInt32(0);

                                }
                            catch (Exception)
                                {
                                return 1;
                                }
                            return povratnaVrijednost + 1;
                            }
                        }
                    }
                }
            catch (SqlException e)
                {
                throw new Exception("Greska prilikom dobavljanja MAX id-a: " + e);
                }
            }
        

    public void dodajTermin(Termin termin)
        {
            throw new NotImplementedException();
        }

        public void dodijeliLijekTerapiji(Lijek lijek)
        {
            throw new NotImplementedException();
        }

        public void izlistajAktuelneNalaze()
        {
            throw new NotImplementedException();
        }

        public void izlistajHistorijuTerapija()
        {
            throw new NotImplementedException();
        }

        public void izlistajNalaze()
        {
            throw new NotImplementedException();
        }

        public void izlistajTrenutnuTerapiju()
        {
            throw new NotImplementedException();
        }

        public List<DateTime> pretragaSlobodnog(DateTime datum, Doktor doktor)
        {
            throw new NotImplementedException();
        }

        public void ukloniLijek(Lijek lijek)
        {
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

                   String sql = "DELETE FROM dbo.Poliklinika_Lijek" + " WHERE nazivLijeka LIKE '" + lijek.NazivLijeka + "' ;";
                    SqlCommand cmdZaTabeluOsoba = new SqlCommand(sql, connection);
                   cmdZaTabeluOsoba.ExecuteNonQuery();

                    connection.Close();




                    }
                }
            catch (SqlException e)
                {
                throw new Exception("Greska prilikom dodavanja medicinske sestre ili doktora : " + e);
                }
            }

    

        public bool zahtjevZaTerminom(DateTime datum, Doktor doktor)
        {
            throw new NotImplementedException();
        }
    }
}
