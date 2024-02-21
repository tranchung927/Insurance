using AutoMapper;
using Server.Data;
using Server.Data.ClientSupport;
using Server.Models.ClientSupport;
using Server.Repositories.ClientSupport.Interface;
using Microsoft.EntityFrameworkCore;

namespace Server.Repositories.ClientSupport
{
    public class ClientSupport_Repo : IRepository<InformationModel>
    {
        private readonly Web_Context _context;
        private readonly IMapper _mapper;

        public ClientSupport_Repo(Web_Context contex, IMapper mapper)
        {
            _context = contex;
            _mapper = mapper;
        }

        async Task<InformationModel> IRepository<InformationModel>.AddNew(InformationModel entity)
        {
            // Ánh xạ dữ liệu từ JobsRiskModel sang JobsRisk
            var NewEntity = _mapper.Map<InformationEntity>(entity);

            // Đính kèm đối tượng mới với context
            _context.Attach(NewEntity);

            // Thêm đối tượng mới vào cơ sở dữ liệu
            _context.Information!.Add(NewEntity);

            // Lưu thay đổi vào cơ sở dữ liệu
            await _context.SaveChangesAsync();

            // Trả về đối tượng mới đã được thêm vào cơ sở dữ liệu
            return _mapper.Map<InformationModel>(NewEntity);
        }

        public async Task Delete(int id)
        {
            // Kiểm tra xem thực thể đã tồn tại trong cơ sở dữ liệu hay không
            var existingEntity = await _context.Information.FindAsync(id);
            if (existingEntity == null)
            {
                // Xử lý trường hợp không tìm thấy thực thể
                return;
            }

            // Cập nhật trường status về 0
            existingEntity.Status = 0;

            await _context.SaveChangesAsync();
        }

        async Task<IEnumerable<InformationModel>> IRepository<InformationModel>.GetAll()
        {
            var EntityList = await _context.Information?.ToListAsync();
            return _mapper.Map<List<InformationModel>>(EntityList);
        }

        async Task<InformationModel> IRepository<InformationModel>.GetById(int id)
        {
            var existingEntity = await _context.Information.FindAsync(id);
            return _mapper.Map<InformationModel>(existingEntity);
        }

        async Task IRepository<InformationModel>.Update(InformationModel entity)
        {
            // Kiểm tra xem thực thể đã tồn tại trong cơ sở dữ liệu hay không
            var existingEntity = await _context.Information.FindAsync(entity.Id);
            if (existingEntity == null)
            {
                // Xử lý trường hợp không tìm thấy thực thể
                return;
            }

            // Kiểm tra xem có null không trước khi truy cập các thuộc tính của nó
            if (entity == null)
            {
                // Xử lý trường hợp NewJobsRisk là null
                return;
            }

            // Cập nhật thuộc tính của thực thể hiện tại với dữ liệu từ NewJobsRisk
            existingEntity.Comment = entity.Comment;
            existingEntity.Status = entity.Status;
            existingEntity.Problem = entity.Problem;

            try
            {
                // Lưu thay đổi vào cơ sở dữ liệu
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error updating entity: {ex.Message}");
                throw;
            }
        }
    }
}
