using System;
using InsuranceCore.Models.DTOs.VehicleProperty;
using InsuranceCore.Models.DTOs.VehicleType;
using InsuranceCore.Responses;
using InsuranceCore.Services.VehiclePropertyService;
using InsuranceCore.Services.VehicleTypeService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace InsuranceCore.Controllers
{
    /// <summary>
    /// Controller used to expose VehicleType resources of the API.
    /// </summary>
    [ApiController]
    [Authorize]
    [Route("[controller]")]
    public class VehicleTypeController : ControllerBase
    {
        private readonly IVehicleTypeService _vehicleTypeService;

        /// <summary>
        /// Initializes a new instance of the <see cref="VehicleTypeController"/> class.
        /// </summary>
        /// <param name="VehicleTypeController"></param>

        public VehicleTypeController(IVehicleTypeService vehicleTypeService)
        {
            _vehicleTypeService = vehicleTypeService;
        }

        /// <summary>
        /// Get list of VehicleTypes.
        /// </summary>
        /// <remarks>
        /// Get list of VehicleTypes. The endpoint uses pagination and sort. Filter(s) can be applied for research.
        /// </remarks>
        /// <param name="parameters"></param>
        /// <returns></returns>
        [HttpGet]
        [AllowAnonymous]
        [ProducesResponseType(typeof(PageInsuranceResponse<GetVehicleTypeDto>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetVehicleTypes()
        {
            var data = await _vehicleTypeService.GetAllVehicleTypes();

            return Ok(new PageInsuranceResponse<GetVehicleTypeDto>(data, 0, 0,
                await _vehicleTypeService.CountVehicleTypesWhere()));
        }

        /// <summary>
        /// Get a VehicleType by giving its Id.
        /// </summary>
        /// <remarks>
        /// Get a VehicleType by giving its Id.
        /// </remarks>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id:int}")]
        [AllowAnonymous]
        [ProducesResponseType(typeof(GetVehicleTypeDto), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(InsuranceErrorResponse), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetVehicleType(int id)
        {
            return Ok(await _vehicleTypeService.GetVehicleType(id));
        }

        /// <summary>
        /// Add a VehicleType.
        /// </summary>
        /// <remarks>
        /// Add a VehicleType.
        /// </remarks>
        /// <param name="VehicleType"></param>
        /// <returns></returns>
        [HttpPost]
        [AllowAnonymous]
        [ProducesResponseType(typeof(GetVehicleTypeDto), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(InsuranceErrorResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(InsuranceErrorResponse), StatusCodes.Status409Conflict)]
        public async Task<IActionResult> AddVehicleType(AddVehicleTypeDto vehicleType)
        {
            return Ok(await _vehicleTypeService.AddVehicleType(vehicleType));
        }

        /// <summary>
        /// Update a VehicleType.
        /// </summary>
        /// <remarks>
        /// Update a VehicleType.
        /// </remarks>
        /// <param name="VehicleType"></param>
        /// <returns></returns>
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [AllowAnonymous]
        [ProducesResponseType(typeof(InsuranceErrorResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(InsuranceErrorResponse), StatusCodes.Status409Conflict)]
        public async Task<IActionResult> UpdateVehicleType(UpdateVehicleTypeDto vehicleType)
        {
            if (await _vehicleTypeService.GetVehicleType(vehicleType.Id) == null)
                return NotFound();
            await _vehicleTypeService.UpdateVehicleType(vehicleType);
            return Ok();
        }

        /// <summary>
        /// Delete a VehicleType by giving its id.
        /// </summary>
        /// <remarks>
        /// Delete a VehicleType by giving its id.
        /// </remarks>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id:int}")]
        [AllowAnonymous]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(InsuranceErrorResponse), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteVehicleType(int id)
        {
            if (await _vehicleTypeService.GetVehicleType(id) == null)
                return NotFound();
            await _vehicleTypeService.DeleteVehicleType(id);
            return Ok();
        }
    }
}
