using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Server.Models.HomeInsurance;
using Server.Models.LifeInsurance;
using Server.Repositories;

namespace Server.Controllers.HomeInsurance
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeInsuranceController : ControllerBase
    {
        // đối tượng _context đại diện cho bảng Information
        private readonly IRepository<HomeCoefficientModel> _context_HomeCoefficient;
        private readonly IRepository<HomeTypeModel> _context_HomeType;
        private readonly IRepository<SizeTypeModel> _context_SizeType;
        private readonly IRepository<RiskCoefficientModel> _context_RiskCoefficientModel;

        public HomeInsuranceController(
            IRepository<HomeCoefficientModel> context_HomeCoefficient,
            IRepository<HomeTypeModel> context_HomeType,
            IRepository<SizeTypeModel> context_SizeType,
            IRepository<RiskCoefficientModel> context_RiskCoefficientModel)
        {
            _context_HomeCoefficient = context_HomeCoefficient;
            _context_HomeType = context_HomeType;
            _context_SizeType = context_SizeType;
            _context_RiskCoefficientModel = context_RiskCoefficientModel;
        }

        [HttpGet("AllHomeCoefficient")]
        public async Task<ActionResult<IEnumerable<HomeCoefficientModel>>> AllHomeCoefficient()
        {
            var entityModelList = await _context_HomeCoefficient.GetAll();
            return Ok(entityModelList);
        }

        [HttpGet("AllHomeType")]
        public async Task<ActionResult<IEnumerable<HomeTypeModel>>> AllHomeType()
        {
            var entityModelList = await _context_HomeType.GetAll();
            return Ok(entityModelList);
        }

        [HttpGet("AllSizeTypeModel")]
        public async Task<ActionResult<IEnumerable<SizeTypeModel>>> AllSizeTypeModel()
        {
            var entityModelList = await _context_SizeType.GetAll();
            return Ok(entityModelList);
        }

        [HttpGet("AllRiskCoefficientModel")]
        public async Task<ActionResult<IEnumerable<RiskCoefficientModel>>> AllRiskCoefficientModel()
        {
            var entityModelList = await _context_RiskCoefficientModel.GetAll();
            return Ok(entityModelList);
        }
    }
}
