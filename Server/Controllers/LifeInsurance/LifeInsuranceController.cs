using Server.Models.ClientSupport;
using Server.Models.LifeInsurance;
using Server.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Server.Controllers.LifeInsurance
{
    [Route("api/[controller]")]
    [ApiController]
    public class LifeInsuranceController : ControllerBase
    {
        // đối tượng _context đại diện cho bảng Information
        private readonly IRepository<DeathRateModel> _context_deathRate;
        private readonly IRepository<JobsRiskModel> _context_jobsRisk;
        private readonly IRepository<WorkplaceModel> _context_workplace;

        public LifeInsuranceController(
            IRepository<DeathRateModel> context, 
            IRepository<JobsRiskModel> context_jobsRisk, 
            IRepository<WorkplaceModel> context_Workplace)
        {
            _context_deathRate = context;
            _context_jobsRisk = context_jobsRisk;
            _context_workplace = context_Workplace;
        }

        [HttpGet("AllDeathRate")]
        public async Task<ActionResult<IEnumerable<DeathRateModel>>> AllDeathRate()
        {
            var entityModelList = await _context_deathRate.GetAll();
            return Ok(entityModelList);
        }

        [HttpGet("AllJobsRisk")]
        public async Task<ActionResult<IEnumerable<JobsRiskModel>>> AllJobsRisk()
        {
            var entityModelList = await _context_jobsRisk.GetAll();
            return Ok(entityModelList);
        }

        [HttpGet("AllWorkplace")]
        public async Task<ActionResult<IEnumerable<WorkplaceModel>>> AllWorkplace()
        {
            var entityModelList = await _context_workplace.GetAll();
            return Ok(entityModelList);
        }

    }
}
