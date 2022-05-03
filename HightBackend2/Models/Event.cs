using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HightBackend.Models
{
    public class Event
    {
        [Key]
        public int eventID { get; set; }

        public string title { get; set; }

        public DateTime time { get; set; }

        public float price { get; set; }

        public string location { get; set; }

        public string eventImage { get; set; }

        public int estabilishmentID { get; set; }

        public virtual Estabilishment estabilishment { get; set; }
    }
}
