using System.Data.SqlClient;

namespace Databaze
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*
            List<Zamestnanec> listZamestnancu = new List<Zamestnanec>();
            */

            /*
            z2.AddObject(z2);
            z1.SelectListOfObject(listZamestnancu);

            foreach(Zamestnanec z in listZamestnancu)
            {
                Console.WriteLine(z);
            }
            */

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
                    Console.WriteLine("Pripojeno");

                    /*
                    string query = "create table Zamestnanec (id int identity(1,1) primary key, jmeno nvarchar(20) not null, dat_nar date not null, vek int not null)";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.ExecuteNonQuery();
                    }
                    */

                    /*
                    string query = "ALTER TABLE Zamestnanec ADD jmeno varchar(20)";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.ExecuteNonQuery();
                    }
                    

                    
                    string query = "INSERT INTO Zamestnanec(text) values('Cs')";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.ExecuteNonQuery();
                    }
                    

                    
                    string query2 = "select * from Zamestnanec";
                    using (SqlCommand command = new SqlCommand(query2, connection))
                    {
                        SqlDataReader reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                            Console.WriteLine(reader[0].ToString() + " " + reader[1].ToString());
                        }
                    }
                    */
                    
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }


            Zamestnanec z1 = new Zamestnanec(1, "David", "2002-02-06", 21);
            Zamestnanec z2 = new Zamestnanec(2, "Michal", "2001-05-05", 22);
            Zamestnanec z3 = new Zamestnanec(3, "Ondrej", "2010-12-24", 13);
            /*
            z1.AddObject(z1);
            z2.AddObject(z2);
            z3.AddObject(z3);
            */

            //z1.SelectObject(z1);
        }
    }
}