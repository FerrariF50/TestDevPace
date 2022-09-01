using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DevPace.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        [HttpGet("[Action]/{userId}")]
        [ProducesResponseType(typeof(CustomerResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(TrooperResponse), StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<TrooperChargeInfoResponse>> GetChargeInfo(int userId)
        {
            _logger.LogInformation($"GetChargeInfo: {userId}");
            try
            {
                var result = await _appService.GetChargeInfoAsync(userId);
                var response = new TrooperChargeInfoResponse { Body = result };
                return response;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                var response = new TrooperChargeInfoResponse
                { HasError = true, Error = (ex.Message + ", Inner:" + ex.InnerException) };
                return StatusCode(StatusCodes.Status500InternalServerError, response);
            }
        }

        [HttpGet("[Action]/{userId}")]
        [ProducesResponseType(typeof(TrooperResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(TrooperResponse), StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<BoolResponse>> ChargeAllTroopersBySparks(int userId)
        {
            _logger.LogInformation($"ChargeAllTroopersBySparks: {userId}");
            try
            {
                var result = await _appService.ChargeAllTroopersBySparksAsync(userId);
                var response = new BoolResponse { Body = result };
                return response;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                var response = new BoolResponse
                { HasError = true, Error = (ex.Message + ", Inner:" + ex.InnerException) };
                return StatusCode(StatusCodes.Status500InternalServerError, response);
            }
        }

        [HttpGet("[Action]/{userId}/{trooperId}")]
        [ProducesResponseType(typeof(TrooperResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(TrooperResponse), StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<BoolResponse>> ChargeTrooperBySparks(int userId, int trooperId)
        {
            _logger.LogInformation($"ChargeTrooperBySparks: {userId} , {trooperId}");
            try
            {
                var result = await _appService.ChargeTrooperBySparksAsync(userId, trooperId);
                var response = new BoolResponse { Body = result };
                return response;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                var response = new BoolResponse
                { HasError = true, Error = (ex.Message + ", Inner:" + ex.InnerException) };
                return StatusCode(StatusCodes.Status500InternalServerError, response);
            }
        }

        [HttpGet("[Action]/{userId}")]
        [ProducesResponseType(typeof(TrooperResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(TrooperResponse), StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<BoolResponse>> ChargeAllTroopersBySparkAndXoil(int userId)
        {
            _logger.LogInformation($"ChargeAllTroopersBySparkAndXoil: {userId}");
            try
            {
                var result = await _appService.ChargeAllTroopersBySparkAndXoil(userId);
                var response = new BoolResponse { Body = result };
                return response;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                var response = new BoolResponse
                { HasError = true, Error = (ex.Message + ", Inner:" + ex.InnerException) };
                return StatusCode(StatusCodes.Status500InternalServerError, response);
            }
        }
    }
}
