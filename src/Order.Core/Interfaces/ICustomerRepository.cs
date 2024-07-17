using Order.Core.Entites;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Order.Infrastructure.Dto;

namespace Order.Core.Interfaces
{
    public interface ICustomerRepository:IGenericRepository<Customer>
    {
        Task<bool> AddAsync(CustomerDto customerDto);
        Task<IEnumerable<OrderCust>> GetOrdersByCustomerIdAsync(int customerId);
    }
}
