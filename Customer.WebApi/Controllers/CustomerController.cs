using CORE.Dto.Requests;
using CORE.Dto.Responses;
using Customer.BAL.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Customer.WebApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerAppService _customerAppSrv;

        public CustomerController(ICustomerAppService customerAppSrv)
        {
            _customerAppSrv = customerAppSrv;
        }

        [HttpPost("[Action]/{customerId}")]
        [ProducesResponseType(typeof(CustomerResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(CustomerResponse), StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<CustomerResponse>> Get(int customerId)
        {
            try
            {
                var result = await _customerAppSrv.GetAsync(customerId);
                var response = new CustomerResponse { Body = result };
                return response;
            }
            catch (Exception ex)
            {
                var response = new CustomerDtoResponse { HasError = true, Error = (ex.Message + ", Inner:" + ex.InnerException) };
                return StatusCode(StatusCodes.Status500InternalServerError, response);
            }
        }

        [HttpGet("[Action]")]
        [ProducesResponseType(typeof(CustomerDtoResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(CustomerDtoResponse), StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<CustomerDtoResponse>> GetAll()
        {
            try
            {
                var result = await _customerAppSrv.GetAllAsync();
                var response = new CustomerDtoResponse { Body = result };
                return response;
            }
            catch (Exception ex)
            {
                var response = new CustomerDtoResponse { HasError = true, Error = (ex.Message + ", Inner:" + ex.InnerException) };
                return StatusCode(StatusCodes.Status500InternalServerError, response);
            }
        }

        [HttpPost("[Action]")]
        [ProducesResponseType(typeof(IntResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(IntResponse), StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IntResponse>> Add([FromBody] CustomerRequestDto dto)
        {
            try
            {
                var result = await _customerAppSrv.AddAsync(dto);
                var response = new IntResponse { Body = result };
                return response;
            }
            catch (Exception ex)
            {
                var response = new IntResponse
                { HasError = true, Error = (ex.Message + ", Inner:" + ex.InnerException) };
                return StatusCode(StatusCodes.Status500InternalServerError, response);
            }
        }

        [HttpDelete("[Action]/{customerId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> Delete(int customerId)
        {
            try
            {
                await _customerAppSrv.DeleteAsync(customerId);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPut("[Action]")]
        [ProducesResponseType(typeof(IntResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(IntResponse), StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IntResponse>> Update([FromBody] CustomerRequestDto dto)
        {
            try
            {
                var result = await _customerAppSrv.UpdateAsync(dto);
                var response = new IntResponse { Body = result };
                return response;
            }
            catch (Exception ex)
            {
                var response = new IntResponse
                { HasError = true, Error = (ex.Message + ", Inner:" + ex.InnerException) };
                return StatusCode(StatusCodes.Status500InternalServerError, response);
            }
        }
    }
}
