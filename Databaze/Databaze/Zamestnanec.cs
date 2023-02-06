using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Databaze
{
    public class Zamestnanec : IBaseClass
    {
        private int id;
        private string jmeno;
        private string dat_nar;
        private int vek;

        public Zamestnanec(int id, string jmeno, string dat_nar, int vek)
        {
            this.id = id;
            this.jmeno = jmeno;
            this.dat_nar = dat_nar;
            this.vek = vek;
        }

        public string Jmeno
        {
            get { return jmeno; }
            set { jmeno = value; }
        }

        public string Dat_nar
        {
            get { return dat_nar; }
            set { dat_nar = value; }
        }

        public int Vek
        {
            get { return vek; }
            set { vek = value; }
        }

        public int ID { get => id; set => id = value; }

        public override string? ToString()
        {
            return this.id + " " + this.jmeno + " " + this.dat_nar + " " + this.vek;
        }

        
        public void AddObject(Zamestnanec z)
        {
            SqlConnectionStringBuilder consStringBuilder = new SqlConnectionStringBuilder();
            consStringBuilder.UserID = "sa";
            consStringBuilder.Password = "student";
            consStringBuilder.InitialCatalog = "test";
            consStringBuilder.DataSource = "PC972";
            consStringBuilder.ConnectTimeout = 30;
            try
            {
                using (SqlConnection connection = new SqlConnection(consStringBuilder.ConnectionString))
                {
                    connection.Open();

                    string query = "INSERT INTO Zamestnanec(jmeno, dat_nar, vek) values(@par1, @par2, @par3)";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@par1", jmeno);
                        command.Parameters.AddWithValue("@par2", dat_nar);
                        command.Parameters.AddWithValue("@par3", vek);
                        command.ExecuteNonQuery();

                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }


        public void SelectObject(Zamestnanec z)
        {
            SqlConnectionStringBuilder consStringBuilder = new SqlConnectionStringBuilder();
            consStringBuilder.UserID = "sa";
            consStringBuilder.Password = "student";
            consStringBuilder.InitialCatalog = "test";
            consStringBuilder.DataSource = "PC972";
            consStringBuilder.ConnectTimeout = 30;
            try
            {
                using (SqlConnection connection = new SqlConnection(consStringBuilder.ConnectionString))
                {
                    connection.Open();

                    string query2 = "select * from Zamestnanec WHERE id='" + z.id + "'";
                    using (SqlCommand command = new SqlCommand(query2, connection))
                    {
                        SqlDataReader reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                            Console.WriteLine(reader[0].ToString() + " " + reader[1].ToString() + " " + reader[2].ToString() + " " + Int32.Parse(reader[3].ToString()));
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public void SelectListOfObject(List<Zamestnanec> listZamestnancu)
        {
            SqlConnectionStringBuilder consStringBuilder = new SqlConnectionStringBuilder();
            consStringBuilder.UserID = "sa";
            consStringBuilder.Password = "student";
            consStringBuilder.InitialCatalog = "test";
            consStringBuilder.DataSource = "PC972";
            consStringBuilder.ConnectTimeout = 30;
            try
            {
                using (SqlConnection connection = new SqlConnection(consStringBuilder.ConnectionString))
                {
                    connection.Open();

                    string query2 = "select * from Zamestnanec";
                    using (SqlCommand command = new SqlCommand(query2, connection))
                    {
                    SqlDataReader reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                                listZamestnancu.Add(new Zamestnanec(Int32.Parse(reader[0].ToString()), reader[1].ToString(), reader[2].ToString(), Int32.Parse(reader[3].ToString())));
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
