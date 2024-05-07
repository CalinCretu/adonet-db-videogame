using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace adonet_db_videogame
{
    public class Videogame
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Overview { get; set; }
        public DateTime ReleaseDate { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set;}
        public int SoftwareHouseId { get; set; } // chiave esterna tabella software_houses

        public Videogame(string name, string overview, DateTime releaseDate, DateTime createdAt, DateTime updatedAt, int softwareHouseId)
        {
            Id = id;
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
        static string connectionString = "Data Source=localhost;Initial Catalog=adonet-db-videogame;Integrated Security=True;Trust Server Certificate=True";
        static void InsertVideogame(string name, string overview, DateTime release_date, DateTime created_at, DateTime updated_at, int software_house_id)
        {
            Videogame NewVideogame = new Videogame(name, overview, release_date, created_at, updated_at, software_house_id);

            string query = "INSERT INTO videogames (name, overview, release_date, created_at, updated_at, software_house_id) VALUES (@name, @overview, @release_date, @created_at, @updated_at, @software_house_id)";

            SqlConnection sqlConnection = new SqlConnection(connectionString);
            try
            {
                sqlConnection.Open();

                SqlCommand cmd = new SqlCommand(query, sqlConnection);
                cmd.Parameters.Add(new SqlParameter("@name", name));
                cmd.Parameters.Add(new SqlParameter("@overview", overview));
                cmd.Parameters.Add(new SqlParameter("@release_date", release_date));
                cmd.Parameters.Add(new SqlParameter("@created_at", created_at));
                cmd.Parameters.Add(new SqlParameter("@updated_at", updated_at));
                cmd.Parameters.Add(new SqlParameter("@software_house_id", software_house_id));

                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            finally
            {
                sqlConnection.Close();
            }
        }
    }
}