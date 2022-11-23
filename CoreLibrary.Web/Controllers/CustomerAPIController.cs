using AutoMapper;
using CoreLibrary.Web.DTOs;
using CoreLibrary.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FluentValidation.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerAPIController : ControllerBase
    {
        private readonly MyDbContext _context;
        private readonly IValidator<Customer> _customerValidator;
        private readonly IMapper _mapper;



        public CustomerAPIController(MyDbContext context, IValidator<Customer> customerValidator, IMapper mapper)
        {
            _context = context;
            _customerValidator = customerValidator;
            _mapper = mapper;
        }


        [Route("MappingOrnek")]
        [HttpGet]
        public IActionResult MappingExample()
        {
            Customer customer = new Customer
            {
                Id = 999,
                Email = "cobanyasin1998@gmail.com",
                Age = 23,
                Name = "Yasin",
                CreditCard = new CreditCard
                {
                    Number = "1234",
                    ValidDate = DateTime.Now,
                }
            };




            return Ok(_mapper.Map<CustomerDTO>(customer));
        }

        [HttpGet]
        public async Task<ActionResult<List<CustomerDTO>>> GetCustomers()
        {
            List<Customer> customers = await _context.Customers.ToListAsync();
            return _mapper.Map<List<CustomerDTO>>(customers);
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<Customer>> GetCustomer(int id)
        {
            var customer = await _context.Customers.FindAsync(id);

            if (customer == null)
            {
                return NotFound();
            }

            return customer;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutCustomer(int id, Customer customer)
        {
            if (id != customer.Id)
            {
                return BadRequest();
            }

            _context.Entry(customer).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CustomerExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        [HttpPost]
        public async Task<ActionResult<Customer>> PostCustomer(Customer customer)
        {
            var result = _customerValidator.Validate(customer);
            if (!result.IsValid)
            {
                return BadRequest(result.Errors.Select(y => new
                {
                    propertyName = y.PropertyName,
                    error = y.ErrorMessage

                }).ToList());
            }
            _context.Customers.Add(customer);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCustomer", new { id = customer.Id }, customer);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCustomer(int id)
        {
            var customer = await _context.Customers.FindAsync(id);
            if (customer == null)
            {
                return NotFound();
            }

            _context.Customers.Remove(customer);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CustomerExists(int id)
        {
            return _context.Customers.Any(e => e.Id == id);
        }
    }
}
