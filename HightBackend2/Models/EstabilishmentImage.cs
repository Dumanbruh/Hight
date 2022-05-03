using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HightBackend.Models
{
    public class EstabilishmentImage
    {
        [Key]
        public int imageID { get; set; }

        public string Title { get; set; }

        public int estabilishmentID { get; set; }

        public virtual Estabilishment Estabilishment { get; set; }
    }
}
