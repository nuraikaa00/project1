using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sweet_shop.Models
{
    public partial class Supplier
    {
        public Supplier()
        {
            Supplies = new HashSet<Supply>();
        }

        public int id { get; set; }
        public string organization { get; set; }
        public string name { get; set; }
        public string number { get; set; }

        public virtual ICollection<Supply> Supplies { get; set; }
    }
}

