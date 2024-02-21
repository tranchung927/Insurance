using Server.Models.ClientSupport;
using Server.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Server.Controllers.ClientSupport
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientSupportController : ControllerBase
    {
        // đối tượng _context đại diện cho bảng Information
        private readonly IRepository<InformationModel> _context;

        public ClientSupportController(IRepository<InformationModel> context)
        {
            _context = context;
        }

        [HttpPost("AddNew")]
        public async Task<ActionResult<InformationModel>> AddNew(InformationModel entityModel)
        {
            await _context.AddNew(entityModel);
            return Ok();
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<IEnumerable<InformationModel>>> GetAll()
        {
            var entityModelList = await _context.GetAll();
            return Ok(entityModelList);
        }

        [HttpPost("Update")]
        public async Task<ActionResult<InformationModel>> Update(InformationModel entityModel)
        {
            await _context.Update(entityModel);
            return Ok();
        }
    }
}
