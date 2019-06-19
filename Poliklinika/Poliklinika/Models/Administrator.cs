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
        const String maxIdOsobeQuery = "SELECT MAX(id) FROM dbo.Poliklinika_Osoba;";
        const String maxIdLoginQuery = "SELECT MAX(id) FROM dbo.Poliklinika_Login;";
        const String maxIdDoktorQuery = "SELECT MAX(id) FROM dbo.Poliklinika_Doktor;";
        const String maxIdMedicinskaSestraQuery = "SELECT MAX(id) FROM dbo.Poliklinika_Medicinska_Sestra;";

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



        public void dodajPacijenta(Login login)
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


                    SqlCommand cmdZaTabeluOsoba = new SqlCommand(@"INSERT INTO dbo.Poliklinika_Osoba (id,ime, prezime, DatumRodjenja, email, MjestoRodjenja)
              VALUES (@id, @ime, @prezime, @DatumRodjenja, @email, @MjestoRodjenja )", connection);
                    int maxId = vratiNajveciID(maxIdPacijentaQuery);
                    cmdZaTabeluOsoba.Parameters.Add(new SqlParameter("id", maxId));
                    cmdZaTabeluOsoba.Parameters.Add(new SqlParameter("ime", login.osoba.Ime));
                    cmdZaTabeluOsoba.Parameters.Add(new SqlParameter("prezime", login.osoba.Prezime));
                    cmdZaTabeluOsoba.Parameters.Add(new SqlParameter("DatumRodjenja", login.osoba.DatumRodjenja));
                    cmdZaTabeluOsoba.Parameters.Add(new SqlParameter("email", login.osoba.Email));
                    cmdZaTabeluOsoba.Parameters.Add(new SqlParameter("MjestoRodjenja", login.osoba.MjestoRodjenja));
                    cmdZaTabeluOsoba.ExecuteNonQuery();

                    //Dodajem pacijenta u tabelu pacijenata
                    SqlCommand cmdZaTabeluPacijent = new SqlCommand(@"INSERT INTO dbo.Poliklinika_Pacijent (id,idOsobeFK)
              VALUES (@id, @idOsobeFK )", connection);


                    cmdZaTabeluPacijent.Parameters.Add(new SqlParameter("id", vratiNajveciID(maxIdPacijentaQuery)));
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




        public void dodajZaposlenika(Login login)
            {

            try
                {
                SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
                builder.DataSource = "ehlimanatest.database.windows.net";
                builder.UserID = "Ehlimana";
                builder.Password = "Ooad2019";
                builder.InitialCatalog = "Database 1";

                String tipTabele = null, queryByType = null;

                //Odredjujem koji je tip instance osobe poslan
                if (login.osoba is Doktor)
                    {
                    tipTabele = "dbo.Poliklinika_Doktor";
                    queryByType = maxIdDoktorQuery;
                    }
                else
                    {
                    tipTabele = "dbo.Poliklinika_Medicinska_Sestra";
                    queryByType = maxIdMedicinskaSestraQuery;
                    }

                using (SqlConnection connection = new SqlConnection(builder.ConnectionString))
                    {

                    connection.Open();
                    StringBuilder sb = new StringBuilder();


                    SqlCommand cmdZaTabeluOsoba = new SqlCommand(@"INSERT INTO dbo.Poliklinika_Osoba (id,ime, prezime, DatumRodjenja, email, MjestoRodjenja)
                    VALUES (@id, @ime, @prezime, @DatumRodjenja, @email, @MjestoRodjenja )", connection);
                    int maxId = vratiNajveciID(queryByType);
                    cmdZaTabeluOsoba.Parameters.Add(new SqlParameter("id", maxId));
                    cmdZaTabeluOsoba.Parameters.Add(new SqlParameter("ime", login.osoba.Ime));
                    cmdZaTabeluOsoba.Parameters.Add(new SqlParameter("prezime", login.osoba.Prezime));
                    cmdZaTabeluOsoba.Parameters.Add(new SqlParameter("DatumRodjenja", login.osoba.DatumRodjenja));
                    cmdZaTabeluOsoba.Parameters.Add(new SqlParameter("email", login.osoba.Email));
                    cmdZaTabeluOsoba.Parameters.Add(new SqlParameter("MjestoRodjenja", login.osoba.MjestoRodjenja));
                    cmdZaTabeluOsoba.ExecuteNonQuery();

                    //Dodajem pacijenta u tabelu pacijenata

                    SqlCommand cmdZaTabeluPacijent = new SqlCommand(@"INSERT INTO " + tipTabele + "(id,idOsobeFK) VALUES (@id, @idOsobeFK )", connection);
                    cmdZaTabeluPacijent.Parameters.Add(new SqlParameter("id", vratiNajveciID(maxIdPacijentaQuery)));
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
                    Console.WriteLine("Uspjesno dodano u " + tipTabele);



                    }
                }
            catch (SqlException e)
                {
                throw new Exception("Greska prilikom dodavanja medicinske sestre ili doktora : " + e);
                }
            }

        public void dodijeliLijekTerapiji(Lijek lijek)
            {
            throw new NotImplementedException();
            }

        public List<Osoba> dajListuPacijenata()
            {
            List<Osoba> listaPacijenata = new List<Osoba>();
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
                    sb.Append("SELECT pc.ime, pc.prezime,  pc.email, pc.MjestoRodjenja, pc.DatumRodjenja");
                    sb.Append("FROM dbo.Poliklinika_Osoba pc, dbo.Poliklinika_Pacijent pp");
                    sb.Append("WHERE pc.id = pp.idOsobeFK; ");

                    String sql = sb.ToString();

                    using (SqlCommand command = new SqlCommand(sql, connection))
                        {
                        using (SqlDataReader reader = command.ExecuteReader())
                            {
                            while (reader.Read())
                                {
                                listaPacijenata.Add(new Pacijent(reader.GetString(0), reader.GetString(1), reader.GetString(2), reader.GetString(3), reader.GetDateTime(4)));
                                }
                            }
                        }
                    }
              
                }
            catch (SqlException e)
                {
               
                Console.WriteLine("Nesto nije uredu sa bazom!");
                Console.WriteLine(e.ToString());
                return null;
                }
            return listaPacijenata;
            }

        public List<Osoba> vratiListuOsoblja()
            {
            List<Osoba> listaOsoblja = new List<Osoba>();
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
                    sb.Append("SELECT pc.ime, pc.prezime,  pc.email, pc.MjestoRodjenja, pc.DatumRodjenja");
                    sb.Append("FROM dbo.Poliklinika_Osoba pc, dbo.Poliklinika_Doktor pp, dbo.Poliklinika_Medicinska_Sestra ms");
                    sb.Append("WHERE pc.id = pp.idOsobeFK OR pc.id= ms.idOsobeFK; ");

                    String sql = sb.ToString();

                    using (SqlCommand command = new SqlCommand(sql, connection))
                        {
                        using (SqlDataReader reader = command.ExecuteReader())
                            {
                            while (reader.Read())
                                {
                                listaOsoblja.Add(new Pacijent(reader.GetString(0), reader.GetString(1), reader.GetString(2), reader.GetString(3), reader.GetDateTime(4)));
                                }
                            }
                        }
                    }

                }
            catch (SqlException e)
                {

                Console.WriteLine("Nesto nije uredu sa bazom!");
                Console.WriteLine(e.ToString());
                return null;
                }
            return listaOsoblja;
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


        public Int32 vratiIdPoLoginu(String username)
            {

            //Kad brisem osobu ili dodajem moram vratit id
            //username mora biti jedinstven, ako vratim -1 znaci da se osoba moze dodati 
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
                  
                     sb.Append("SELECT pc.idOsobeFK ");
                     sb.Append("FROM dbo.Poliklinika_Login pc ");
                    sb.Append("WHERE pc.username LIKE '" + username +"';");

                    String sql = sb.ToString();

                    using (SqlCommand command = new SqlCommand(sql, connection))
                        {
                        using (SqlDataReader reader = command.ExecuteReader())
                            {
                            //Ukoliko je tabela prazna
                            int povratnaVrijednost = 0;
                          

                            reader.Read();

                            try
                                {
                                povratnaVrijednost = reader.GetInt32(0);

                                }
                            catch (Exception)
                                {
                                return -1;
                                }
                            return povratnaVrijednost;
                            }
                        }
                    }
                }
            catch (SqlException e)
                {

                Console.WriteLine("Nesto nije uredu sa bazom " + e);
                return -1;
               
                }
            
            }


        public void obrisiOsobu(Login login)
            {
            try
                {
                SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
                builder.DataSource = "ehlimanatest.database.windows.net";
                builder.UserID = "Ehlimana";
                builder.Password = "Ooad2019";
                builder.InitialCatalog = "Database 1";

                String tipTabele = null;

                if (login.osoba is Doktor) tipTabele = "dbo.Poliklinika_Doktor";
                else if (login.osoba is MedicinskaSestra) tipTabele = "dbo.Poliklinika_Medicinska_Sestra";
                else
                    {
                    tipTabele = "dbo.Poliklinika_Pacijent";
                    }

                Int32 idOsobe = vratiIdPoLoginu(login.username);
                if (idOsobe == -1) throw new IndexOutOfRangeException("Osoba ne postoji!");
                using (SqlConnection connection = new SqlConnection(builder.ConnectionString))
                    {


                    connection.Open();
                    StringBuilder sb = new StringBuilder();
                    sb.Append("DELETE FROM dbo.Poliklinika_Osoba  WHERE id=" + idOsobe+ ";" );
                   String sql = sb.ToString();

                    SqlCommand command = new SqlCommand(sql, connection);
                    sql = "DELETE FROM " + tipTabele + " WHERE idOsobeFK=" + idOsobe + ";";
                    command = new SqlCommand(sql, connection);
                    sql = "DELETE FROM dbo.Poliklinika_Login WHERE idOsobeFK=" + idOsobe + ";";
                    command = new SqlCommand(sql, connection);

                    }
                Console.WriteLine("Osoba uspjesno obrisana!");
                }
            catch (SqlException e)
                {

                Console.WriteLine("Nesto nije uredu sa bazom!");
                Console.WriteLine(e.ToString());
               
                }
            catch (IndexOutOfRangeException e)
                {
                Console.WriteLine("Nesto nije uredu sa bazom!");
                Console.WriteLine(e.ToString());

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
                            return povratnaVrijednost+1;
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
