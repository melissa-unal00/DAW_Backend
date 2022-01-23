using System;
using System.Collections.Generic;
using DAW_Project.Models.Base;

namespace DAW_Project.Models
{
    public class Order : BaseEntity
    {
        public float TotalPrice { get; set; }

        public User User { get; set; }
        public Guid UserId { get; set; } //FK

        public DeliveryAddress DeliveryAddress { get; set; }

        public ICollection<OrderProductRelation> OrderProductRelations { get; set; }
    }
}