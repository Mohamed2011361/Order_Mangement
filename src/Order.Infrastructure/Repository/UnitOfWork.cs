using AutoMapper;
using Order.Core.Interfaces;
using Order.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order.Infrastructure.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public UnitOfWork(ApplicationDbContext context,IMapper mapper)
        {
            _context = context;
            this._mapper = mapper;
            CustomerRepository = new CustomerRepository(_context,_mapper);
            InvoiceRepository = new InvoiceRepository(_context);
            ProductRepository = new ProductRepository(_context);
            OrderRepository = new OrderCustRepository(_context);
            OrderItemRepository = new OrderItemRepository(_context);
        }
        public ICustomerRepository CustomerRepository { get; }

        public IinvoiceRepository InvoiceRepository { get; }

        public IProductRepository ProductRepository { get; }

        public IOrderCustRepository OrderRepository { get; }

        public IOrderItemRepository OrderItemRepository { get; }

        public async Task<int> CompleteAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
