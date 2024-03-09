using System;
using System.Collections.Generic;

namespace DatabaseFirstAproachMVC.Models
{
    public partial class Category
    {
        public int CategoryId { get; set; }
        public string? CategoryName { get; set; }
        public string? Descripton { get; set; }
    }
}
