using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order.Core.Interfaces
{
    public interface IUnitOfWork
    {
        public ICustomerRepository CustomerRepository { get; }
        public IinvoiceRepository InvoiceRepository { get;  }
        public IProductRepository ProductRepository { get; }
        public IOrderCustRepository OrderRepository { get; }
        public  IOrderItemRepository OrderItemRepository { get;  }
        Task<int> CompleteAsync();
    }
}
