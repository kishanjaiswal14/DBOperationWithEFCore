using DBOperationWithEFCore.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Runtime.InteropServices;

namespace DBOperationWithEFCore.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly AppDBContext _appDBContext;

        public CustomerController(AppDBContext appDBContext)
        {
            _appDBContext = appDBContext;
        }

        [HttpGet]
        public async Task<IActionResult> GetNoOrderCustomers()
        {
            var customers =await (from customer in _appDBContext.Customers
                            where !(from order in _appDBContext.Orders select order.CustomerId).Contains(
                                customer.CustomerId) select customer).ToListAsync();

            return Ok(customers);
        }
    }
}
