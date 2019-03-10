using System;
using System.ComponentModel.DataAnnotations;

namespace CustomSite.Entities
{
    public class Product : EntityBase
    {
        [Required]
        public string ProductName { get; set; }
        [Required]
        public string Manufactory { get; set; }
        [Required]
        public string ProductPrice { get; set; }
        public string ProductDescription { get; set; }

        public Guid CategoryId { get; set; }
        public Category Category { get; set; }
    }
}