using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CustomSite.Entities
{
    public class Category : EntityBase
    {
        [Required]
        public string CategoryName { get; set; }
        public string CategoryDescription { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}