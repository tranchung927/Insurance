using InsuranceCore.Models.DTOs.HouseRiskCoefficient;
using InsuranceCore.Responses;
using InsuranceCore.Services.HouseRiskCoefficient;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace InsuranceCore.Controllers
{

    /// <summary>
    /// Controller used to expose HouseRiskCoefficient resources of the API.
    /// </summary>
    [ApiController]
    [Authorize]
    [Route("[controller]")]
    public class HouseRiskCoefficienController : ControllerBase
    {
        private readonly IHouseRiskCoefficientService _HouseRiskCoefficientService;
        /// <summary>
        /// Initializes a new instance of the <see cref="HouseRiskCoefficientController"/> class.
        /// </summary>
        /// <param name="HouseController"></param>

        public HouseRiskCoefficienController(IHouseRiskCoefficientService HouseRiskCoefficientService)
        {
            _HouseRiskCoefficientService = HouseRiskCoefficientService;

        }

        /// <summary>
        /// Get list of HouseRiskCoefficients.
        /// </summary>
        /// <remarks>
        /// Get list of HouseRiskCoefficients. The endpoint uses pagination and sort. Filter(s) can be applied for research.
        /// </remarks>
        /// <param name="parameters"></param>
        /// <returns></returns>
        [HttpGet]
        [AllowAnonymous]
        [ProducesResponseType(typeof(PageInsuranceResponse<GetHouseRiskCoefficientDto>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetHouseRiskCoefficients()
        {
            var data = await _HouseRiskCoefficientService.GetAllHouseRiskCoefficients();

            return Ok(new PageInsuranceResponse<GetHouseRiskCoefficientDto>(data, 0, 0,
                await _HouseRiskCoefficientService.CountHouseRiskCoefficientsWhere()));
        }

        /// <summary>
        /// Get a HouseRiskCoefficient by giving its Id.
        /// </summary>
        /// <remarks>
        /// Get a HouseRiskCoefficient by giving its Id.
        /// </remarks>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id:int}")]
        [AllowAnonymous]
        [ProducesResponseType(typeof(GetHouseRiskCoefficientDto), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(InsuranceErrorResponse), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetHouseRiskCoefficient(int id)
        {
            return Ok(await _HouseRiskCoefficientService.GetHouseRiskCoefficient(id));
        }

        /// <summary>
        /// Add a HouseRiskCoefficient.
        /// </summary>
        /// <remarks>
        /// Add a HouseRiskCoefficient.
        /// </remarks>
        /// <param name="HouseRiskCoefficient"></param>
        /// <returns></returns>
        [HttpPost]
        [AllowAnonymous]
        [ProducesResponseType(typeof(GetHouseRiskCoefficientDto), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(InsuranceErrorResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(InsuranceErrorResponse), StatusCodes.Status409Conflict)]
        public async Task<IActionResult> AddHouseRiskCoefficient(AddHouseRiskCoefficientDto HouseRiskCoefficient)
        {
            return Ok(await _HouseRiskCoefficientService.AddHouseRiskCoefficient(HouseRiskCoefficient));
        }

        /// <summary>
        /// Update a HouseRiskCoefficient.
        /// </summary>
        /// <remarks>
        /// Update a HouseRiskCoefficient.
        /// </remarks>
        /// <param name="HouseRiskCoefficient"></param>
        /// <returns></returns>
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [AllowAnonymous]
        [ProducesResponseType(typeof(InsuranceErrorResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(InsuranceErrorResponse), StatusCodes.Status409Conflict)]
        public async Task<IActionResult> UpdateHouseRiskCoefficient(UpdateHouseRiskCoefficientDto HouseRiskCoefficient)
        {
            if (await _HouseRiskCoefficientService.GetHouseRiskCoefficient(HouseRiskCoefficient.Id) == null)
                return NotFound();
            await _HouseRiskCoefficientService.UpdateHouseRiskCoefficient(HouseRiskCoefficient);
            return Ok();
        }

        /// <summary>
        /// Delete a HouseRiskCoefficient by giving its id.
        /// </summary>
        /// <remarks>
        /// Delete a HouseRiskCoefficient by giving its id.
        /// </remarks>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id:int}")]
        [AllowAnonymous]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(InsuranceErrorResponse), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteHouseRiskCoefficient(int id)
        {
            if (await _HouseRiskCoefficientService.GetHouseRiskCoefficient(id) == null)
                return NotFound();
            await _HouseRiskCoefficientService.DeleteHouseRiskCoefficient(id);
            return Ok();
        }
    }
}
