using System;
using InsuranceCore.Models.DTOs.Workplace;
using InsuranceCore.Responses;
using InsuranceCore.Services.Workplace;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace InsuranceCore.Controllers
{
    /// <summary>
    /// Controller used to expose Workplace resources of the API.
    /// </summary>
    [ApiController]
    [Authorize]
    [Route("[controller]")]
    public class WorkplaceController : ControllerBase
    {
        private readonly IWorkplaceService _workplaceService;
        /// <summary>
        /// Initializes a new instance of the <see cref="WorkplaceController"/> class.
        /// </summary>
        /// <param name="WorkplaceService"></param>

        public WorkplaceController(IWorkplaceService workplaceService)
        {
            _workplaceService = workplaceService;
        }

        /// <summary>
        /// Get list of Workplaces.
        /// </summary>
        /// <remarks>
        /// Get list of Workplaces. The endpoint uses pagination and sort. Filter(s) can be applied for research.
        /// </remarks>
        /// <param name="parameters"></param>
        /// <returns></returns>
        [HttpGet]
        [AllowAnonymous]
        [ProducesResponseType(typeof(PageInsuranceResponse<GetWorkplaceDto>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetWorkplaces()
        {
            var data = await _workplaceService.GetAllWorkplaces();

            return Ok(new PageInsuranceResponse<GetWorkplaceDto>(data, 0, 0,
                await _workplaceService.CountWorkplacesWhere()));
        }

        /// <summary>
        /// Get a Workplace by giving its Id.
        /// </summary>
        /// <remarks>
        /// Get a Workplace by giving its Id.
        /// </remarks>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id:int}")]
        [AllowAnonymous]
        [ProducesResponseType(typeof(GetWorkplaceDto), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(InsuranceErrorResponse), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await _workplaceService.GetWorkplace(id));
        }

        /// <summary>
        /// Add a Workplace.
        /// </summary>
        /// <remarks>
        /// Add a Workplace.
        /// </remarks>
        /// <param name="Workplace"></param>
        /// <returns></returns>
        [HttpPost]
        [AllowAnonymous]
        [ProducesResponseType(typeof(GetWorkplaceDto), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(InsuranceErrorResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(InsuranceErrorResponse), StatusCodes.Status409Conflict)]
        public async Task<IActionResult> AddWorkplace(AddWorkplaceDto workplace)
        {
            return Ok(await _workplaceService.AddWorkplace(workplace));
        }

        /// <summary>
        /// Update a Workplace.
        /// </summary>
        /// <remarks>
        /// Update a Workplace.
        /// </remarks>
        /// <param name="Workplace"></param>
        /// <returns></returns>
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [AllowAnonymous]
        [ProducesResponseType(typeof(InsuranceErrorResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(InsuranceErrorResponse), StatusCodes.Status409Conflict)]
        public async Task<IActionResult> UpdateWorkplace(UpdateWorkplaceDto workplace)
        {
            if (await _workplaceService.GetWorkplace(workplace.Id) == null)
                return NotFound();
            await _workplaceService.UpdateWorkplace(workplace);
            return Ok();
        }

        /// <summary>
        /// Delete a Workplace by giving its id.
        /// </summary>
        /// <remarks>
        /// Delete a Workplace by giving its id.
        /// </remarks>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id:int}")]
        [AllowAnonymous]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(InsuranceErrorResponse), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteWorkplace(int id)
        {
            if (await _workplaceService.GetWorkplace(id) == null)
                return NotFound();
            await _workplaceService.DeleteWorkplace(id);
            return Ok();
        }
    }
}
