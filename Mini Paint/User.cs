using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;


namespace Princes_Escape
{
    public class Glowna
    {
        #region wlasciwosci
        private static SQLiteConnection _Polaczenie;
        public static SQLiteConnection Polaczenie
        {
            get
            {
                if (!File.Exists(Path.Combine(Application.StartupPath, "Highscore.db")))
                {
                    _Polaczenie = new SQLiteConnection(string.Format("Data Source={0}", Path.Combine(Application.StartupPath, "Highscore.db")));
                    _Polaczenie.Open();

                    zapytanieSQL = string.Format("create table if not exists Highscore(Id integer primary key autoincrement, Wynik integer, Nazwa varchar(30))");
                    Komenda = new SQLiteCommand(zapytanieSQL, Polaczenie);
                    Komenda.ExecuteNonQuery();

                    _Polaczenie.Close();
                }
                else

                    if (_Polaczenie == null)
                    _Polaczenie = new SQLiteConnection(string.Format("Data Source={0}", Path.Combine(Application.StartupPath, "Highscore.db")));
                return _Polaczenie;


            }
        }

        public static SQLiteCommand Komenda;
        public static SQLiteDataReader CZytnik;
        public static string zapytanieSQL = "";

        public static string GetMd5Hash(MD5 md5Hash, string input)
        {
            byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));

            StringBuilder sBuilder = new StringBuilder();

            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }
            return sBuilder.ToString();
        }
        #endregion wlasciwosci
    }

    public class Users : Glowna
    {
        #region wlasciwosci
        public static bool DodajUsera(int wynik, string nazwa)
        {
            bool status = false;
            
            
            try
            {
                if (Polaczenie.State == ConnectionState.Closed)
                {
                    Polaczenie.Open();

                    zapytanieSQL = string.Format("create table if not exists Highscore(Id integer primary key autoincrement,Wynik integer,Nazwa varchar(30)");
                    Komenda = new SQLiteCommand(zapytanieSQL, Polaczenie);
           

                    zapytanieSQL = string.Format("insert into Highscore(Wynik,Nazwa) values({0},'{1}')", wynik, nazwa);
                    Komenda = new SQLiteCommand(zapytanieSQL, Polaczenie);
                    Komenda.ExecuteNonQuery();
                }
                else
                {
                    MessageBox.Show("NIE Polaczono z baza danych.");
                }
                Polaczenie.Close();
            }
            catch (Exception e)
            {
                string blad = string.Format("Problem podczas dodawania usera:\n{0}", e.Message);
                MessageBox.Show(blad, "Błąd!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Polaczenie.Close();
            }
            return status;

        }

        public static bool UsunUsera(int id, bool powiadomienie = true)
        {
            bool status = false;

            try
            {
                if (Polaczenie.State == ConnectionState.Closed)
                    Polaczenie.Open();


                zapytanieSQL = string.Format("select Count(Id) from Highscore where Id={0}", id);

                Komenda = new SQLiteCommand(zapytanieSQL, Polaczenie);

                int liczba = Convert.ToInt32(Komenda.ExecuteScalar());
                if (liczba == 1)
                {
                    zapytanieSQL = string.Format("delete from Highscore where Id={0}", id);
                    Komenda.CommandText = zapytanieSQL;
                    Komenda.ExecuteNonQuery();

                    status = true;
                    if (powiadomienie)
                    {
                        MessageBox.Show("User usuniety.", "Informacja", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }
                }
                else if (liczba == 0)
                {
                    MessageBox.Show("User NIEusuniety.", "Informacja", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    status = false;
                }
            }
            catch (Exception e)
            {
                string blad = string.Format("Problem podczas usuwania usera:\n{0}", e.Message);
                MessageBox.Show(blad, "Błąd!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Polaczenie.Close();
            }
            return status;

        }

        public static List<User> ListaUserow
        {
            get
            {
                List<User> lista = new List<User>();

                try
                {
                    if (Polaczenie.State == ConnectionState.Closed)
                        Polaczenie.Open();

                    zapytanieSQL = string.Format("select * from Highscore");
                    Komenda = new SQLiteCommand(zapytanieSQL, Polaczenie);
                    CZytnik = Komenda.ExecuteReader();

                    if (CZytnik.HasRows)
                    {
                        while (CZytnik.Read())
                        {
                            lista.Add(new User(CZytnik.GetInt32(0), CZytnik.GetInt32(1), CZytnik["Nazwa"].ToString()));
                        }
                        CZytnik.Close();

                    }


                }
                catch (Exception e)
                {
                    string blad = string.Format("Problem podczas pobierania danych :\n{0}", e.Message);
                    MessageBox.Show(blad, "Błąd!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    Polaczenie.Close();

                }
                return lista;
            }
        }

        internal static void DodajUsera(int lkrokow, object ksywka)
        {
            throw new NotImplementedException();
        }

        #endregion wlasciwosci
    }

    public class User
    {
        public int Id { get; set; }
        public int Wynik { get; set; }
        public string Nazwa { get; set; }

        public User() { }

        public User(int id, int wynik, string nazwa)
        {
            this.Id = id;
            this.Wynik = wynik;
            this.Nazwa = nazwa;
        }

    }
}
