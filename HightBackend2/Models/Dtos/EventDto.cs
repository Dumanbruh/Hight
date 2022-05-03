using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HightBackend.Models
{
    public class EventDto
    {
        public int eventID { get; set; }

        public string title { get; set; }

        public DateTime time { get; set; }

        public string eventImage { get; set; }

        public string estabilishmentName { get; set; }

    }
}
