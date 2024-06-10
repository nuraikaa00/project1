using sweet_shop.Models;
using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace sweet_shop
{
    public partial class Inventory
    {
        public Inventory()
        {
           
        }

        public int Id { get; set; }
        public int Name { get; set; }
        public int? Measurement_id { get; set; }
        public decimal? Amount { get; set; }
        public int? Staff_id { get; set; }
        public decimal? Amount_Supp { get; set; }
        public decimal? Diff { get; set; }
        public DateTime? Date { get; set; }

        public virtual Measurement Measurement { get; set; }
        public virtual Staff Staff { get; set; }
        public virtual Supply Supply { get; set; }

    }
}
