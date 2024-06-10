using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace sweet_shop
{
    public partial class Ingredient
    {
        public int Id { get; set; }
        public int? ProductId { get; set; }
        public int? SupplyId { get; set; }
        public decimal? Amount { get; set; }

        public virtual Product Product { get; set; }
        public virtual Supply Supply { get; set; }
    }
}
