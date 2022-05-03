using System.ComponentModel.DataAnnotations;

namespace HightBackend.Models
{
    public class EstabilishmentType
    {
        [Key]
        public int typeID { get; set; }

        public string typeName { get; set; }
    }
}
