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
    public class HouseController : ControllerBase
    {
        private readonly IHouseCoefficientService _houseCoefficientService;
        private readonly IHouseSizeService _houseSizeService;
        private readonly IHouseTypeService _houseTypeService;
        /// <summary>
        /// Initializes a new instance of the <see cref="HouseCoefficientController"/> class.
        /// </summary>
        /// <param name="HouseController"></param>

        public HouseController(IHouseCoefficientService HouseCoefficientService, IHouseSizeService houseSizeService, IHouseTypeService houseTypeService)
        {
            _houseCoefficientService = HouseCoefficientService;
            _houseSizeService = houseSizeService;
            _houseTypeService = houseTypeService;
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
        public async Task<IActionResult> GetVehicleHouseSizes()
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
        public async Task<IActionResult> GetHouseTypet(int id)
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
