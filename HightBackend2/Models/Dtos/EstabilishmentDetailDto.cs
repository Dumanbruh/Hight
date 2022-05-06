using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HightBackend.Models.Dtos
{
    public class EstabilishmentDetailDto
    {
        public int estabilishmentId { get; set; }

        public string typeName { get; set; }

        public string name { get; set; }

        public string description { get; set; }

        public string website { get; set; }

        public string location { get; set; }

        public float? reviewNum { get; set; }

        public float? overallRating { get; set; }

        public float? locationRating { get; set; }

        public float? serviceRating { get; set; }

        public float? price_qualityRating { get; set; }

        public List<Comment> comments { get; set; }

        public List<EstabilishmentImage> estabilishmentImages { get; set; }

        public List<Event> events { get; set; }
    }
}
