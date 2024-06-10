using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace sweet_shop
{
    public partial class Measurement
    {
        public Measurement()
        {
            Product = new HashSet<Product>();
            Supply = new HashSet<Supply>();
            Inventory = new HashSet<Inventory>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Product> Product { get; set; }
        public virtual ICollection<Supply> Supply { get; set; }
        public virtual ICollection<Inventory> Inventory { get; set; }
    }
}
