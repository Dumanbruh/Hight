using System;

namespace HightBackend.Models.Dtos
{
    public class CommentDto
    {
        public string comment { get; set; }

        public DateTime publishedDate { get; set; }

        public float? overallRating { get; set; }

        public float? locationRating { get; set; }

        public float? serviceRating { get; set; }

        public float? price_qualityRating { get; set; }
    }
}
