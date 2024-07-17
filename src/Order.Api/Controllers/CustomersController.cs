using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Order.Core.Dto;
using Order.Core.Entites;
using Order.Core.Interfaces;
using Order.Infrastructure.Dto;

namespace Order.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly IUnitOfWork _uOW;
        private readonly IMapper _mapper;

        public CustomersController(IUnitOfWork UOW,IMapper mapper)
        {
            _uOW = UOW;
            _mapper = mapper;
        }
        [HttpPost]
        public async Task<ActionResult> CreateCustomer( CustomerDto customerDto)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var res =await _uOW.CustomerRepository.AddAsync(customerDto);
                    return res ? Ok (customerDto) : BadRequest(res);
                }
                return BadRequest(customerDto);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
        [HttpGet("{customerId}/orders")]
        public async Task<ActionResult>GetOrdersByCustomerId(int customerId)
        {
            var orders = await _uOW.CustomerRepository.GetOrdersByCustomerIdAsync(customerId);
            if (orders == null || !orders.Any())
            {
                return NotFound();
            }

            var res = _mapper.Map<IEnumerable<OrderCustDto>>(orders); // Map to List<OrderDto>
            return Ok(res);
        }

    }
}
