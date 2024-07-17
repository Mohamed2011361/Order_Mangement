using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order.Core.Entites
{
    public class OrderItem:BaseEntity<int>
    {
       
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal Discount { get; set; }
        public int OrderCustId { get; set; }
        public  OrderCust OrderCust { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
    }
}
