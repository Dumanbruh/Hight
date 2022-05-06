using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HightBackend.Models
{
    public class User
    {
        [Key]
        public int userID { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public byte[] PasswordHash { get; set; }

        public byte[] PasswordSalt { get; set; }

        public ICollection<Comment> comments { get; set; }

        public ICollection<usersFavourites> favourites { get; set;}
    }
}
