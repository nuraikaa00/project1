using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace sweet_shop
{
    public partial class Staff
    {
        public Staff()
        {
            ProductionOfProduct = new HashSet<ProductionOfProduct>();
            PurchaseOfSupply = new HashSet<PurchaseOfSupply>();
            SaleOfProduct = new HashSet<SaleOfProduct>();
            Inventory = new HashSet<Inventory>();
        }

        public int Id { get; set; }
        public string Fio { get; set; }
        public int? PositionId { get; set; }
        public decimal? Salary { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }

        public virtual Position Position { get; set; }
        public virtual ICollection<ProductionOfProduct> ProductionOfProduct { get; set; }
        public virtual ICollection<PurchaseOfSupply> PurchaseOfSupply { get; set; }
        public virtual ICollection<SaleOfProduct> SaleOfProduct { get; set; }

        public virtual ICollection<Inventory> Inventory { get; set; }

    }
}
