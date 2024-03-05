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
    /// Controller used to expose HouseTypeController resources of the API.
    /// </summary>
    [ApiController]
    [Authorize]
    [Route("[controller]")]
    public class HouseTypeController : ControllerBase
    {
        private readonly IHouseTypeService _houseTypeService;
        /// <summary>
        /// Initializes a new instance of the <see cref="HouseTypeController"/> class.
        /// </summary>
        /// <param name="HouseTypeController"></param>

        public HouseTypeController(IHouseTypeService houseTypeService)
        {
            _houseTypeService = houseTypeService;
        }

        /// <summary>
        /// Get list of HouseType.
        /// </summary>
        /// <remarks>
        /// Get list of HouseType. The endpoint uses pagination and sort. Filter(s) can be applied for research.
        /// </remarks>
        /// <param name="parameters"></param>
        /// <returns></returns>
        [HttpGet]
        [AllowAnonymous]
        [ProducesResponseType(typeof(PageInsuranceResponse<GetHouseTypeDto>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetHouseTypes()
        {
            var data = await _houseTypeService.GetAllHouseTypes();

            return Ok(new PageInsuranceResponse<GetHouseTypeDto>(data, 0, 0,
                await _houseTypeService.CountHouseTypesWhere()));
        }

        /// <summary>
        /// Get a HouseType by giving its Id.
        /// </summary>
        /// <remarks>
        /// Get a HouseType by giving its Id.
        /// </remarks>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id:int}")]
        [AllowAnonymous]
        [ProducesResponseType(typeof(GetHouseTypeDto), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(InsuranceErrorResponse), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetHouseType(int id)
        {
            return Ok(await _houseTypeService.GetHouseType(id));
        }

        /// <summary>
        /// Add a HouseType.
        /// </summary>
        /// <remarks>
        /// Add a HouseType.
        /// </remarks>
        /// <param name="HouseType"></param>
        /// <returns></returns>
        [HttpPost]
        [AllowAnonymous]
        [ProducesResponseType(typeof(GetHouseTypeDto), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(InsuranceErrorResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(InsuranceErrorResponse), StatusCodes.Status409Conflict)]
        public async Task<IActionResult> AddHouseType(AddHouseTypeDto houseType)
        {
            return Ok(await _houseTypeService.AddHouseType(houseType));
        }

        /// <summary>
        /// Update a HouseType.
        /// </summary>
        /// <remarks>
        /// Update a HouseType.
        /// </remarksHouseType
        /// <param name="HouseCoefficient"></param>
        /// <returns></returns>
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [AllowAnonymous]
        [ProducesResponseType(typeof(InsuranceErrorResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(InsuranceErrorResponse), StatusCodes.Status409Conflict)]
        public async Task<IActionResult> UpdateHouseType(UpdateHouseTypeDto houseType)
        {
            if (await _houseTypeService.GetHouseType(houseType.Id) == null)
                return NotFound();
            await _houseTypeService.UpdateHouseType(houseType);
            return Ok();
        }

        /// <summary>
        /// Delete a HouseType by giving its id.
        /// </summary>
        /// <remarks>
        /// Delete a HouseType by giving its id.
        /// </remarks>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id:int}")]
        [AllowAnonymous]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(InsuranceErrorResponse), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteHouseType(int id)
        {
            if (await _houseTypeService.GetHouseType(id) == null)
                return NotFound();
            await _houseTypeService.DeleteHouseType(id);
            return Ok();
        }
    }
}
