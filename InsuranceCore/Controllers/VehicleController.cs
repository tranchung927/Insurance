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
    public class VehicleController : ControllerBase
    {
        private readonly IVehicleTypeService _vehicleTypeService;
        private readonly IVehiclePropertyService _vehiclePropertyService;
        /// <summary>
        /// Initializes a new instance of the <see cref="VehicleTypeController"/> class.
        /// </summary>
        /// <param name="VehicleController"></param>

        public VehicleController(IVehicleTypeService vehicleTypeService, IVehiclePropertyService vehiclePropertyService)
        {
            _vehicleTypeService = vehicleTypeService;
            _vehiclePropertyService = vehiclePropertyService;
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


        /// <summary>
        /// Get list of VehicleProperty.
        /// </summary>
        /// <remarks>
        /// Get list of VehicleProperty. The endpoint uses pagination and sort. Filter(s) can be applied for research.
        /// </remarks>
        /// <param name="parameters"></param>
        /// <returns></returns>
        [HttpGet]
        [AllowAnonymous]
        [ProducesResponseType(typeof(PageInsuranceResponse<GetVehiclePropertyDto>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetVehicleProperties()
        {
            var data = await _vehiclePropertyService.GetAllVehicleProperties();

            return Ok(new PageInsuranceResponse<GetVehiclePropertyDto>(data, 0, 0,
                await _vehiclePropertyService.CountVehiclePropertysWhere()));
        }

        /// <summary>
        /// Get a VehicleProperty by giving its Id.
        /// </summary>
        /// <remarks>
        /// Get a VehicleProperty by giving its Id.
        /// </remarks>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id:int}")]
        [AllowAnonymous]
        [ProducesResponseType(typeof(GetVehiclePropertyDto), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(InsuranceErrorResponse), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetVehicleProperty(int id)
        {
            return Ok(await _vehiclePropertyService.GetVehicleProperty(id));
        }

        /// <summary>
        /// Add a VehicleProperty.
        /// </summary>
        /// <remarks>
        /// Add a VehicleProperty.
        /// </remarks>
        /// <param name="VehicleProperty"></param>
        /// <returns></returns>
        [HttpPost]
        [AllowAnonymous]
        [ProducesResponseType(typeof(GetVehiclePropertyDto), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(InsuranceErrorResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(InsuranceErrorResponse), StatusCodes.Status409Conflict)]
        public async Task<IActionResult> AddVehicleProperty(AddVehiclePropertyDto vehicleProperty)
        {
            return Ok(await _vehiclePropertyService.AddVehicleProperty(vehicleProperty));
        }

        /// <summary>
        /// Update a VehicleProperty.
        /// </summary>
        /// <remarks>
        /// Update a VehicleProperty.
        /// </remarks>
        /// <param name="VehicleProperty"></param>
        /// <returns></returns>
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [AllowAnonymous]
        [ProducesResponseType(typeof(InsuranceErrorResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(InsuranceErrorResponse), StatusCodes.Status409Conflict)]
        public async Task<IActionResult> UpdateVehicleProperty(UpdateVehiclePropertyDto vehicleProperty)
        {
            if (await _vehiclePropertyService.GetVehicleProperty(vehicleProperty.Id) == null)
                return NotFound();
            await _vehiclePropertyService.UpdateVehicleProperty(vehicleProperty);
            return Ok();
        }

        /// <summary>
        /// Delete a VehicleProperty by giving its id.
        /// </summary>
        /// <remarks>
        /// Delete a VehicleProperty by giving its id.
        /// </remarks>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id:int}")]
        [AllowAnonymous]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(InsuranceErrorResponse), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteVehicleProperty(int id)
        {
            if (await _vehiclePropertyService.GetVehicleProperty(id) == null)
                return NotFound();
            await _vehiclePropertyService.DeleteVehicleProperty(id);
            return Ok();
        }
    }
}
