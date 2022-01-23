using System.Collections.Generic;
using DAW_Project.Models.Base;

namespace DAW_Project.Models
{
    public class Category : BaseEntity
    {
        public string Name { get; set; }

        public ICollection<Product> Products { get; set; }
    }
}