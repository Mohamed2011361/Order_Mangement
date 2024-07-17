using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Order.Core.Entites;
using Order.Core.Interfaces;
using Order.Infrastructure.Data;
using Order.Infrastructure.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order.Infrastructure.Repository
{
    public class CustomerRepository : GenericRepository<Customer>, ICustomerRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public CustomerRepository(ApplicationDbContext context,IMapper mapper) : base(context)
        {
            this._context = context;
            this._mapper = mapper;
        }

        public async Task<bool> AddAsync(CustomerDto customerDto)
        {
            var res = _mapper.Map<Customer>(customerDto);
            await _context.Customers.AddAsync(res);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<OrderCust>> GetOrdersByCustomerIdAsync(int customerId)
            =>await _context.orderCusts.Where(x=>x.CustomerId==customerId).Include(x => x.OrderItems).ToListAsync();
        
    }
}
