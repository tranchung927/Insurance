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
    /// Controller used to expose HouseSizeController resources of the API.
    /// </summary>
    [ApiController]
    [Authorize]
    [Route("[controller]")]
    public class HouseSizeController : ControllerBase
    {
     
        private readonly IHouseSizeService _houseSizeService;

        /// <summary>
        /// Initializes a new instance of the <see cref="HouseSizeController"/> class.
        /// </summary>
        /// <param name="HouseSizeController"></param>

        public HouseSizeController(IHouseSizeService houseSizeService)
        {
          
            _houseSizeService = houseSizeService;
         
        }

        /// <summary>
        /// Get list of HouseSize.
        /// </summary>
        /// <remarks>
        /// Get list of HouseSize. The endpoint uses pagination and sort. Filter(s) can be applied for research.
        /// </remarks>
        /// <param name="parameters"></param>
        /// <returns></returns>
        [HttpGet]
        [AllowAnonymous]
        [ProducesResponseType(typeof(PageInsuranceResponse<GetHouseSizeDto>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetHouseSizes()
        {
            var data = await _houseSizeService.GetAllHouseSizes();

            return Ok(new PageInsuranceResponse<GetHouseSizeDto>(data, 0, 0,
                await _houseSizeService.CountHouseSizesWhere()));
        }

        /// <summary>
        /// Get a HouseSize by giving its Id.
        /// </summary>
        /// <remarks>
        /// Get a HouseSize by giving its Id.
        /// </remarks>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id:int}")]
        [AllowAnonymous]
        [ProducesResponseType(typeof(GetHouseSizeDto), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(InsuranceErrorResponse), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetHouseSize(int id)
        {
            return Ok(await _houseSizeService.GetHouseSize(id));
        }

        /// <summary>
        /// Add a HouseSize.
        /// </summary>
        /// <remarks>
        /// Add a HouseSize.
        /// </remarks>
        /// <param name="HouseSize"></param>
        /// <returns></returns>
        [HttpPost]
        [AllowAnonymous]
        [ProducesResponseType(typeof(GetHouseSizeDto), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(InsuranceErrorResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(InsuranceErrorResponse), StatusCodes.Status409Conflict)]
        public async Task<IActionResult> AddHouseSize(AddHouseSizeDto HouseSize)
        {
            return Ok(await _houseSizeService.AddHouseSize(HouseSize));
        }

        /// <summary>
        /// Update a HouseSize.
        /// </summary>
        /// <remarks>
        /// Update a HouseSize.
        /// </remarks>
        /// <param name="HouseSize"></param>
        /// <returns></returns>
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [AllowAnonymous]
        [ProducesResponseType(typeof(InsuranceErrorResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(InsuranceErrorResponse), StatusCodes.Status409Conflict)]
        public async Task<IActionResult> UpdateHouseSize(UpdateHouseSizeDto HouseSize)
        {
            if (await _houseSizeService.GetHouseSize(HouseSize.Id) == null)
                return NotFound();
            await _houseSizeService.UpdateHouseSize(HouseSize);
            return Ok();
        }

        /// <summary>
        /// Delete a HouseSize by giving its id.
        /// </summary>
        /// <remarks>
        /// Delete a HouseSize by giving its id.
        /// </remarks>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id:int}")]
        [AllowAnonymous]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(InsuranceErrorResponse), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteHouseSize(int id)
        {
            if (await _houseSizeService.GetHouseSize(id) == null)
                return NotFound();
            await _houseSizeService.DeleteHouseSize(id);
            return Ok();
        }
    }
}
