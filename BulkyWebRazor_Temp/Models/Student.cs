using System.ComponentModel.DataAnnotations;

namespace BulkyWebRazor_Temp.Models
{
    public class Student {

        [Key]
        public int id { get; set; }

        [Required]
        public string name { get; set; }
        public string dept { get; set; }
    }
}
