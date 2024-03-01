using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Server.Data.VehicleInsurance;
using Server.Models.VehicleInsurance;
using Server.Repositories;

namespace Server.Controllers.VehicleInsurance
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehicleInsuranceController : ControllerBase
    {
        // đối tượng _context đại diện cho từng bảng 
        private readonly IRepository<VehiclePropertyModel> _context_VehicleProperty;
        private readonly IRepository<VehicleTypeModel> _context_VehicleType;

        public VehicleInsuranceController(
            IRepository<VehiclePropertyModel> context_VehicleProperty,
            IRepository<VehicleTypeModel> context_VehicleType

            )
        {
            _context_VehicleProperty = context_VehicleProperty;
            _context_VehicleType = context_VehicleType;
        }

        [HttpGet("AllVehicleProperty")]
        public async Task<ActionResult<IEnumerable<VehiclePropertyModel>>> AllVehicleProperty()
        {
            var entityModelList = await _context_VehicleProperty.GetAll();
            return Ok(entityModelList);
        }



        [HttpGet("AllVehicleType")]
        public async Task<ActionResult<IEnumerable<VehicleTypeModel>>> AllVehicleType()
        {
            var entityModelList = await _context_VehicleType.GetAll();
            return Ok(entityModelList);
        }
    }
}
