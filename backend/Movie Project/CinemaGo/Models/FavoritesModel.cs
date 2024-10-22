using System.ComponentModel.DataAnnotations;

namespace CinemaGo.Models
{
    public class FavoritesModel
    {
        [Key]
        public int FavId { get; set; }
        public string id { get; set; }  // Unique ID for the favorite entry
        public string Title { get; set; }  // Title of the movie

        public string Description { get; set; }

        public string image { get; set; }

        public string thumbnail { get; set; }

        public float rating { get; set; }

        public int year { get; set; }

        public string email { get; set; }

        public string big_image { get; set; }




    }
}

