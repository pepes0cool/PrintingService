using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
namespace SSPS.Models
{
    public class History
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string UserID { get; set; }

        [ForeignKey("UserID")]
        [ValidateNever]
        public User User { get; set; }

        [Required]
        public int PrinterID { get; set; }

        [ForeignKey("PrinterID")]
        [ValidateNever]
        public Printer Printer { get; set; }

        public int paperNum { get; set; }

        public string status { get; set; }

        public DateTime date { get; set; }
    }
}
