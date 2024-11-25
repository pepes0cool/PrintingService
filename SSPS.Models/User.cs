using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace SSPS.Models
{
    public class User : IdentityUser
    {
        [Required]
        public string? MSSV { get; set; }
        [Required]
        public string? Name { get; set; }
    }
}
