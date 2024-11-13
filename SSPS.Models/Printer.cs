using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
namespace SSPS.Models
{
    public class Printer
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Model { get; set; }
        [Required]
        public string SerialNumber { get; set; }
        public int paperNumber { get; set; }
    }
}
