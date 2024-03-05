using System;
using InsuranceCore.Models.DTOs.DeathRate;
using InsuranceCore.Responses;
using InsuranceCore.Services.DeathRate;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace InsuranceCore.Controllers
{
    /// <summary>
    /// Controller used to expose DeathRate resources of the API.
    /// </summary>
    [ApiController]
    [Authorize]
    [Route("[controller]")]
    public class DeathRateController : ControllerBase
    {
        private readonly IDeathRateService _deathRateService;
        /// <summary>
        /// Initializes a new instance of the <see cref="DeathRateController"/> class.
        /// </summary>
        /// <param name="DeathRateService"></param>

        public DeathRateController(IDeathRateService deathRateService)
        {
            _deathRateService = deathRateService;
        }

        /// <summary>
        /// Get list of DeathRates.
        /// </summary>
        /// <remarks>
        /// Get list of DeathRates. The endpoint uses pagination and sort. Filter(s) can be applied for research.
        /// </remarks>
        /// <param name="parameters"></param>
        /// <returns></returns>
        [HttpGet]
        [AllowAnonymous]
        [ProducesResponseType(typeof(PageInsuranceResponse<GetDeathRateDto>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetDeathRates()
        {
            var data = await _deathRateService.GetAllDeathRates();

            return Ok(new PageInsuranceResponse<GetDeathRateDto>(data, 0, 0,
                await _deathRateService.CountDeathRatesWhere()));
        }

        /// <summary>
        /// Get a DeathRate by giving its Id.
        /// </summary>
        /// <remarks>
        /// Get a DeathRate by giving its Id.
        /// </remarks>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id:int}")]
        [AllowAnonymous]
        [ProducesResponseType(typeof(GetDeathRateDto), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(InsuranceErrorResponse), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await _deathRateService.GetDeathRate(id));
        }

        /// <summary>
        /// Add a DeathRate.
        /// </summary>
        /// <remarks>
        /// Add a DeathRate.
        /// </remarks>
        /// <param name="DeathRate"></param>
        /// <returns></returns>
        [HttpPost]
        [AllowAnonymous]
        [ProducesResponseType(typeof(GetDeathRateDto), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(InsuranceErrorResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(InsuranceErrorResponse), StatusCodes.Status409Conflict)]
        public async Task<IActionResult> AddDeathRate(AddDeathRateDto DeathRate)
        {
            return Ok(await _deathRateService.AddDeathRate(DeathRate));
        }

        /// <summary>
        /// Update a DeathRate.
        /// </summary>
        /// <remarks>
        /// Update a DeathRate.
        /// </remarks>
        /// <param name="DeathRate"></param>
        /// <returns></returns>
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [AllowAnonymous]
        [ProducesResponseType(typeof(InsuranceErrorResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(InsuranceErrorResponse), StatusCodes.Status409Conflict)]
        public async Task<IActionResult> UpdateDeathRate(UpdateDeathRateDto DeathRate)
        {
            if (await _deathRateService.GetDeathRate(DeathRate.Id) == null)
                return NotFound();
            await _deathRateService.UpdateDeathRate(DeathRate);
            return Ok();
        }

        /// <summary>
        /// Delete a DeathRate by giving its id.
        /// </summary>
        /// <remarks>
        /// Delete a DeathRate by giving its id.
        /// </remarks>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id:int}")]
        [AllowAnonymous]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(InsuranceErrorResponse), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteDeathRate(int id)
        {
            if (await _deathRateService.GetDeathRate(id) == null)
                return NotFound();
            await _deathRateService.DeleteDeathRate(id);
            return Ok();
        }
    }
}
