using sweet_shop.Models;
using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace sweet_shop
{
    public partial class Supply
    {
        public Supply()
        {
            Ingredient = new HashSet<Ingredient>();
            PurchaseOfSupply = new HashSet<PurchaseOfSupply>();
            Inventory = new HashSet<Inventory>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int? MeasurementId { get; set; }
        public decimal? Amount { get; set; }
        public int? SupplierID { get; set; }

        public virtual Measurement Measurement { get; set; }
        public virtual Supplier Supplier { get; set; }
        public virtual ICollection<Ingredient> Ingredient { get; set; }
        public virtual ICollection<PurchaseOfSupply> PurchaseOfSupply { get; set; }
        public virtual ICollection<Inventory> Inventory { get; set; }
    }
}
