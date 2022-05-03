using System;
using System.ComponentModel.DataAnnotations;

namespace HightBackend.Models
{
    public class Comment
    {
        [Key]
        public int commentID { get; set; }

        public string comment { get; set; }

        public DateTime publishedDate { get; set; }

        public float overallRating { get; set; }

        public float locationRating { get; set; }

        public float serviceRating { get; set; }

        public float price_qualityRating { get; set; }

        public int estabilishmentID { get; set; }

        public virtual Estabilishment estabilishment { get; set; }

        public int userID { get; set; }

        public virtual User user { get; set; }
    }
}
