using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace adonet_db_videogame
{
    public class Videogame
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Overview { get; set; }
        public DateTime ReleaseDate { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public long SoftwareHouseId { get; set; } // chiave esterna tabella software_houses

        public Videogame(string name, string overview, DateTime releaseDate, DateTime createdAt, DateTime updatedAt, long softwareHouseId)
        {
            Name = name;
            Overview = overview;
            ReleaseDate = releaseDate;
            CreatedAt = createdAt;
            UpdatedAt = updatedAt;
            SoftwareHouseId = softwareHouseId;
        }
    }

    public static class VideogameManager
    {
        static string connectionString = "Data Source=localhost;Initial Catalog=adonet-db-videogame;Integrated Security=True";
        public static void InsertVideogame(string name, string overview)
        {
            using SqlConnection sqlConnection = new SqlConnection(connectionString);

            try
            {
                sqlConnection.Open();

                string query = "INSERT INTO videogames (name, overview, release_date, created_at, updated_at, software_house_id) VALUES (@name, @overview, @release_date, @created_at, @updated_at, @software_house_id)";

                using SqlCommand cmd = new SqlCommand(query, sqlConnection);
                {
                    cmd.Parameters.Add(new SqlParameter("@name", name));
                    cmd.Parameters.Add(new SqlParameter("@overview", overview));
                    cmd.Parameters.Add(new SqlParameter("@release_date", "1985-01-01"));
                    cmd.Parameters.Add(new SqlParameter("@created_at", "1985-01-01"));
                    cmd.Parameters.Add(new SqlParameter("@updated_at", "2002-01-01"));
                    cmd.Parameters.Add(new SqlParameter("@software_house_id", "1"));

                    int affectedRows = cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
        public static Videogame GetVideogameById(int id)
        {
            string query = "SELECT * FROM videogames WHERE id = @id";
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Open();
                SqlCommand cmd = new SqlCommand(query, sqlConnection);
                cmd.Parameters.AddWithValue("@id", id);

                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    return new Videogame(
                        reader["name"].ToString(),
                        reader["overview"].ToString(),
                        Convert.ToDateTime(reader["release_date"]),
                        Convert.ToDateTime(reader["created_at"]),
                        Convert.ToDateTime(reader["updated_at"]),
                        (long)reader["software_house_id"]
                    );
                }
            }
            return null;
        }
    }
}