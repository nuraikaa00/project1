using sweet_shop.Models;
using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace sweet_shop
{
    public partial class Product
    {
        public Product()
        {
            Ingredient = new HashSet<Ingredient>();
            ProductionOfProduct = new HashSet<ProductionOfProduct>();
            SaleOfProduct = new HashSet<SaleOfProduct>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int? MeasurementId { get; set; }
        public decimal? Amount { get; set; }
        public decimal? Sum { get; set; }
       

        public virtual Measurement Measurement { get; set; }

      
        public virtual ICollection<Ingredient> Ingredient { get; set; }
        public virtual ICollection<ProductionOfProduct> ProductionOfProduct { get; set; }
        public virtual ICollection<SaleOfProduct> SaleOfProduct { get; set; }
      
    }
}

