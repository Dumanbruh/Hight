using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace HightBackend.Models
{
    public class Comment
    {
        [Key]
        public int commentID { get; set; }

        public string comment { get; set; }

        public DateTime publishedDate { get; set; }

        [DefaultValue(0)]
        public float? overallRating { get; set; }

        [DefaultValue(0)]
        public float? locationRating { get; set; }

        [DefaultValue(0)]
        public float? serviceRating { get; set; }

        [DefaultValue(0)]
        public float? price_qualityRating { get; set; }

        public int estabilishmentID { get; set; }

        public virtual Estabilishment estabilishment { get; set; }

        public int userID { get; set; }

        public virtual User user { get; set; }
    }
}
