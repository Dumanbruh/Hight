using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HightBackend.Models.Dtos
{
    public class EstabilishmentDto
    {
        public int estabilishmentId { get; set; }

        public string typeName { get; set; }

        public string name { get; set; }

        public string website { get; set; }

        public float reviewNum { get; set; }

        public string imageTitle { get; set; }

        public float overallRating { get; set; }


        public string location { get; set; }

    }
}
