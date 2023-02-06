using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Databaze
{
    internal class ZamestnanecDAO : IDAO<Zamestnanec>
    {
        public void Delete(Zamestnanec zamestnanec)
        {
            SqlConnection conn = DatabaseSingleton.GetInstance();

            using (SqlCommand command = new SqlCommand("DELETE FROM Zamestnanec WHERE id = @id", conn))
            {
                command.Parameters.Add(new SqlParameter("@id", zamestnanec.Id));
                command.ExecuteNonQuery();
                zamestnanec.Id = 0;
            }
        }

        public IEnumerable<Zamestnanec> GetAll()
        {
            SqlConnection conn = DatabaseSingleton.GetInstance();

            using (SqlCommand command = new SqlCommand("SELECT * FROM Zamestnanec", conn))
            {
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Zamestnanec zamestnanec = new Zamestnanec(
                        Convert.ToInt32(reader[0].ToString()),
                        reader[1].ToString(),
                        reader[2].ToString(),
                        Convert.ToInt32(reader[3].ToString())
                    );
                    yield return zamestnanec;
                }
                reader.Close();
            }
        }

        public Zamestnanec? GetByID(int id)
        {
            Zamestnanec? zamestnanec = null;
            SqlConnection connection = DatabaseSingleton.GetInstance();
            // 1. declare command object with parameter
            using (SqlCommand command = new SqlCommand("SELECT * FROM Zamestnanec WHERE id = @Id", connection))
            {
                // 2. define parameters used in command 
                SqlParameter param = new SqlParameter();
                param.ParameterName = "@Id";
                param.Value = id;

                // 3. add new parameter to command object
                command.Parameters.Add(param);
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    zamestnanec = new Zamestnanec(
                        Convert.ToInt32(reader[0].ToString()),
                        reader[1].ToString(),
                        reader[2].ToString(),
                        Convert.ToInt32(reader[3].ToString())
                        );
                }
                reader.Close();
            }

            return zamestnanec;

        }

        public void Save(Zamestnanec zamestnanec)
        {
            SqlConnection conn = DatabaseSingleton.GetInstance();

            SqlCommand command = null;

            if (zamestnanec.Id < 1)
            {
                using (command = new SqlCommand("INSERT INTO Zamestnanec (jmeno, vek) VALUES (@jmeno, @vek)", conn))
                {
                    command.Parameters.Add(new SqlParameter("@jmeno", zamestnanec.Jmeno));
                    command.Parameters.Add(new SqlParameter("@vek", zamestnanec.Vek));
                    command.ExecuteNonQuery();
                    //zjistim id posledniho vlozeneho zaznamu
                    command.CommandText = "Select @@Identity";
                    zamestnanec.Id = Convert.ToInt32(command.ExecuteScalar());
                }
            }
            else
            {
                using (command = new SqlCommand("UPDATE Zamestnanec SET jmeno = @jmeno, vek = @vek " +
                    "WHERE id = @id", conn))
                {
                    command.Parameters.Add(new SqlParameter("@id", zamestnanec.Id));
                    command.Parameters.Add(new SqlParameter("@jmeno", zamestnanec.Jmeno));
                    command.Parameters.Add(new SqlParameter("@vek", zamestnanec.Vek));
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
