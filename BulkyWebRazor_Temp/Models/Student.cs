using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BulkyWebRazor_Temp.Models
{
    public class Student {

        [Key]
        public int id { get; set; }

        [Required]
        [DisplayName("Name")]
        
        public string name { get; set; }
        [DisplayName("Department")]
        public string dept { get; set; }
    }
}
