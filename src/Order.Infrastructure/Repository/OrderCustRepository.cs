using Order.Core.Entites;
using Order.Core.Interfaces;
using Order.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order.Infrastructure.Repository
{
    public class OrderCustRepository : GenericRepository<OrderCust>, IOrderCustRepository
    {
        public OrderCustRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
