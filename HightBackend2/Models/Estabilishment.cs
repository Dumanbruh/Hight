using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HightBackend.Models
{
    public class Estabilishment
    {
        [Key]
        public int estabilishmentId { get; set; }

        [Required]
        public string name { get; set; }

        public string description { get; set; }

        public string website { get; set; }

        public string location { get; set; }

        [DefaultValue(0)]
        public float? reviewNum { get; set; }

        [DefaultValue(0)]
        public float? overallRating { get; set; }

        [DefaultValue(0)]
        public float? locationRating { get; set; }

        [DefaultValue(0)]
        public float? serviceRating { get; set; }

        [DefaultValue(0)]
        public float? price_qualityRating { get; set; }

        public virtual EstabilishmentType type { get; set;}

        public ICollection<EstabilishmentImage> estabilishmentImage { get; set; }

        public ICollection<Event> events { get; set; }

        public ICollection<Comment> comments { get; set; }


    }
}
