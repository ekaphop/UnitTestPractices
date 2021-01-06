using System;
using System.Collections.Generic;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using UnitTestPractices.BSL;
using UnitTestPractices.DTO;
using UnitTestPractices.Exceptions;

namespace UnitTestPractices.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class CustomerProfileController : ControllerBase
    {
        private readonly ILogger<CustomerProfileController> logger;
        private readonly ICustomerService customerService;

        public CustomerProfileController(
            ILogger<CustomerProfileController> logger,
            ICustomerService customerService
            )
        {
            this.logger = logger;
            this.customerService = customerService;
        }

        [HttpGet("{id}")]
        public ActionResult Customer(int id)
        {
            try
            {
                return Ok(customerService.GetCustomerById(id));
            }
            catch (ArgumentException ex)
            {
                logger.LogError(ex, ex.Message);
                return BadRequest();
            }
            catch (DataNotFoundException ex)
            {
                logger.LogError(ex, ex.Message);
                return NoContent();
            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpGet]
        public ActionResult<IEnumerable<Customer>> Customers()
        {
            try
            {
                return Ok(customerService.GetCustomers());
            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}
