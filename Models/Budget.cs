using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace sweet_shop
{
    public partial class Budget
    {
        public int Id { get; set; }
        public decimal? SumOfBudget { get; set; }
       
    }
}
