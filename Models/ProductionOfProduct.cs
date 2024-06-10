using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace sweet_shop
{
    public partial class ProductionOfProduct
    {
        public int Id { get; set; }
        public int? ProductId { get; set; }
        public decimal? Amount { get; set; }
        public DateTime? Date { get; set; }
        public decimal? Prize { get; set; }
        public int? StaffId { get; set; }

        public virtual Product Product { get; set; }
        public virtual Staff Staff { get; set; }
    }
}
