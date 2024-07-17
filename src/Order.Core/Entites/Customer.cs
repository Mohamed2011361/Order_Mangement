using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order.Core.Entites
{
    public class Customer:BaseEntity<int>
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public ICollection<OrderCust> Orders { get; set; } = new HashSet<OrderCust>();
    }
}
