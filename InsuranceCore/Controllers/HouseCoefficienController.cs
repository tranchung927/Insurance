using System;
using InsuranceCore.Models.DTOs.HouseSize;
using InsuranceCore.Models.DTOs.HouseCoefficient;
using InsuranceCore.Responses;
using InsuranceCore.Services.HouseCoefficient;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using InsuranceCore.Services.HouseSize;
using InsuranceCore.Services.HouseType;
using InsuranceCore.Models.DTOs.HouseType;

namespace InsuranceCore.Controllers
{
    /// <summary>
    /// Controller used to expose HouseCoefficient resources of the API.
    /// </summary>
    [ApiController]
    [Authorize]
    [Route("[controller]")]
    public class HouseCoefficienController : ControllerBase
    {
        private readonly IHouseCoefficientService _houseCoefficientService;
        /// <summary>
        /// Initializes a new instance of the <see cref="HouseCoefficientController"/> class.
        /// </summary>
        /// <param name="HouseController"></param>

        public HouseCoefficienController(IHouseCoefficientService HouseCoefficientService)
        {
            _houseCoefficientService = HouseCoefficientService;
            
        }

        /// <summary>
        /// Get list of HouseCoefficients.
        /// </summary>
        /// <remarks>
        /// Get list of HouseCoefficients. The endpoint uses pagination and sort. Filter(s) can be applied for research.
        /// </remarks>
        /// <param name="parameters"></param>
        /// <returns></returns>
        [HttpGet]
        [AllowAnonymous]
        [ProducesResponseType(typeof(PageInsuranceResponse<GetHouseCoefficientDto>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetHouseCoefficients()
        {
            var data = await _houseCoefficientService.GetAllHouseCoefficients();

            return Ok(new PageInsuranceResponse<GetHouseCoefficientDto>(data, 0, 0,
                await _houseCoefficientService.CountHouseCoefficientsWhere()));
        }

        /// <summary>
        /// Get a HouseCoefficient by giving its Id.
        /// </summary>
        /// <remarks>
        /// Get a HouseCoefficient by giving its Id.
        /// </remarks>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id:int}")]
        [AllowAnonymous]
        [ProducesResponseType(typeof(GetHouseCoefficientDto), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(InsuranceErrorResponse), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetHouseCoefficient(int id)
        {
            return Ok(await _houseCoefficientService.GetHouseCoefficient(id));
        }

        /// <summary>
        /// Add a HouseCoefficient.
        /// </summary>
        /// <remarks>
        /// Add a HouseCoefficient.
        /// </remarks>
        /// <param name="HouseCoefficient"></param>
        /// <returns></returns>
        [HttpPost]
        [AllowAnonymous]
        [ProducesResponseType(typeof(GetHouseCoefficientDto), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(InsuranceErrorResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(InsuranceErrorResponse), StatusCodes.Status409Conflict)]
        public async Task<IActionResult> AddHouseCoefficient(AddHouseCoefficientDto houseCoefficient)
        {
            return Ok(await _houseCoefficientService.AddHouseCoefficient(houseCoefficient));
        }

        /// <summary>
        /// Update a HouseCoefficient.
        /// </summary>
        /// <remarks>
        /// Update a HouseCoefficient.
        /// </remarks>
        /// <param name="HouseCoefficient"></param>
        /// <returns></returns>
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [AllowAnonymous]
        [ProducesResponseType(typeof(InsuranceErrorResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(InsuranceErrorResponse), StatusCodes.Status409Conflict)]
        public async Task<IActionResult> UpdateHouseCoefficient(UpdateHouseCoefficientDto houseCoefficient)
        {
            if (await _houseCoefficientService.GetHouseCoefficient(houseCoefficient.Id) == null)
                return NotFound();
            await _houseCoefficientService.UpdateHouseCoefficient(houseCoefficient);
            return Ok();
        }

        /// <summary>
        /// Delete a HouseCoefficient by giving its id.
        /// </summary>
        /// <remarks>
        /// Delete a HouseCoefficient by giving its id.
        /// </remarks>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id:int}")]
        [AllowAnonymous]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(InsuranceErrorResponse), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteHouseCoefficient(int id)
        {
            if (await _houseCoefficientService.GetHouseCoefficient(id) == null)
                return NotFound();
            await _houseCoefficientService.DeleteHouseCoefficient(id);
            return Ok();
        }
    }
}
