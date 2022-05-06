using System.ComponentModel.DataAnnotations;

namespace HightBackend.Models
{
    public class usersFavourites
    {
        [Key]
        public int favID { get; set; }

        [Required]
        public int userID { get; set; }

        public int estabilishmentID { get; set; }

        public Estabilishment estabilishment { get; set; }

        public User user { get; set; }
    }
}
