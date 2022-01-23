using System;
using System.Collections.Generic;
using DAW_Project.Models.Base;

namespace DAW_Project.Models
{
    public class Product : BaseEntity
    {
        public string Name { get; set; }
        public float Price { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }

        public ICollection<OrderProductRelation> OrderProductRelations { get; set; }

        public Category Category { get; set; }
        public Guid CategoryId { get; set; } //FK
    }
}