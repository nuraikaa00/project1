using System;
using System.Collections.Generic;

namespace sweet_shop
{
    public partial class Category
    {
        public Category()
        {
            Expence = new HashSet<Expence>();
        }
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Expence> Expence { get; set; }
    }
}
