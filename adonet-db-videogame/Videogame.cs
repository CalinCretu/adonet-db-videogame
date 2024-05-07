using System;
using System.Collections.Generic;
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

        public Videogame(int id, string name, string overview, DateTime releaseDate, DateTime createdAt, DateTime updatedAt, int softwareHouseId)
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
        static void InsertVideogame( int id, string name, string overview, DateTime release_date, DateTime created_at, DateTime updated_at, int software_house_id)
        {
            Videogame NewVideogame = new Videogame(id, name, overview, release_date, created_at, updated_at, software_house_id);
        }
    }
}
