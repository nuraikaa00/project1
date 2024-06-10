using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace sweet_shop
{
    public partial class Expence
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? CategoryId { get; set; }
        public decimal? Summ { get; set; }
        public string Comment { get; set; }
        public DateTime? Date { get; set; }


        public virtual Category Category { get; set; }
    }
}
