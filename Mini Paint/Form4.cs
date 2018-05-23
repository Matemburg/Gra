using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using System.Data.SQLite;
using System.IO;


namespace Princes_Escape
{
    public partial class Form4 : Form
    {

        SQLiteConnection Polaczenie = new SQLiteConnection(string.Format("Data Source={0}", Path.Combine(Application.StartupPath, "Highscore.db")));

        public static List<User> ListaUserow = null;

        public static void InicjalizacjaDanych()
        {
            ListaUserow = Users.ListaUserow;

            int licznik = 1;
            foreach (User u in ListaUserow)
            {
                ListViewItem item = new ListViewItem(licznik.ToString());
                item.SubItems.Add(u.Nazwa);
                item.SubItems.Add(u.Wynik.ToString());
                licznik++;
            }
        }

        public Form4()
        {
            InitializeComponent();

        }



        private void Form4_Load(object sender, EventArgs e)
        {

            try
            {
                if (Polaczenie.State == ConnectionState.Closed)
                    Polaczenie.Open();

                DataTable dtbl = new DataTable();
                SQLiteDataAdapter sqlDa = new SQLiteDataAdapter("select Nazwa, Wynik from Highscore order by Wynik desc", Polaczenie);
                sqlDa.Fill(dtbl);
                dataGridView1.DataSource = dtbl;


            }
            catch (Exception ex)
            {
                string blad = string.Format("Problem :\n{0}", ex.Message);
                MessageBox.Show(blad, "Błąd!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Polaczenie.Close();
            }


        }

        private void tablica_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
