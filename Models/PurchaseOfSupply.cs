using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace sweet_shop
{
    public partial class PurchaseOfSupply
    {
        public int Id { get; set; }
        public int? SupplyId { get; set; }
        public decimal? Amount { get; set; }
        public decimal? Sum { get; set; }
        public DateTime? Date { get; set; }
        public int? StaffId { get; set; }

        public virtual Staff Staff { get; set; }
        public virtual Supply Supply { get; set; }
    }
}
