using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DatabaseFirstAproachMVC.Models
{
    public partial class TblUser
    {
        public int UserId { get; set; }
        [Required]
        public string? UserName { get; set; }
        [Required]
        public string? Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string? UserPassword { get; set; }
    }
}
