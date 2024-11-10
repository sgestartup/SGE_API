using Microsoft.AspNetCore.Mvc;

namespace apiweb.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomersRepository _customersRepository;

        public CustomerController(ICustomersRepository customersRepository)
        {
            _customersRepository = customersRepository;
        }

        [HttpPost]
        public async Task<IActionResult> createCustomer(Customers customers)
        {
            await _customersRepository.CreateCustomer(customers);
            return Ok(customers);
        }

        [HttpGet]
        public async Task<IActionResult> getAllCustomers()
        {
            var customers = await _customersRepository.GetAllCustomers();
            return Ok(customers);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> getCustomerById(int id)
        {
            var customer = await _customersRepository.GetCustomerById(id);
            return Ok(customer);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> updateCustomer(int id)
        {
            await _customersRepository.UpdateCustomer2(id);
            return Ok(id);
        }

    }
}