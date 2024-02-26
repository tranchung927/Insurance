using AutoMapper;
using Server.Data;
using Server.Data.ClientSupport;
using Server.Models.ClientSupport;
using Server.Repositories.ClientSupport.Interface;
using Microsoft.EntityFrameworkCore;

namespace Server.Repositories.ClientSupport
{
    public class ClientSupport_Repo : IRepository<TicketModel>
    {
        private readonly Web_Context _context;
        private readonly IMapper _mapper;

        public ClientSupport_Repo(Web_Context contex, IMapper mapper)
        {
            _context = contex;
            _mapper = mapper;
        }

        async Task<TicketModel> IRepository<TicketModel>.AddNew(TicketModel entity)
        {
            // Ánh xạ dữ liệu từ JobsRiskModel sang JobsRisk
            var NewEntity = _mapper.Map<TicketEntity>(entity);

            // Đính kèm đối tượng mới với context
            _context.Attach(NewEntity);

            // Thêm đối tượng mới vào cơ sở dữ liệu
            _context.Ticket!.Add(NewEntity);

            // Lưu thay đổi vào cơ sở dữ liệu
            await _context.SaveChangesAsync();

            // Trả về đối tượng mới đã được thêm vào cơ sở dữ liệu
            return _mapper.Map<TicketModel>(NewEntity);
        }

        public async Task Delete(int id)
        {
            // Kiểm tra xem thực thể đã tồn tại trong cơ sở dữ liệu hay không
            var existingEntity = await _context.Ticket.FindAsync(id);
            if (existingEntity == null)
            {
                // Xử lý trường hợp không tìm thấy thực thể
                return;
            }

            // Cập nhật trường status về 0
            existingEntity.Status = 0;

            await _context.SaveChangesAsync();
        }

        async Task<IEnumerable<TicketModel>> IRepository<TicketModel>.GetAll()
        {
            var EntityList = await _context.Ticket?.ToListAsync();
            return _mapper.Map<List<TicketModel>>(EntityList);
        }

        async Task<TicketModel> IRepository<TicketModel>.GetById(int id)
        {
            var existingEntity = await _context.Ticket.FindAsync(id);
            return _mapper.Map<TicketModel>(existingEntity);
        }

        async Task IRepository<TicketModel>.Update(TicketModel entity)
        {
            // Kiểm tra xem thực thể đã tồn tại trong cơ sở dữ liệu hay không
            var existingEntity = await _context.Ticket.FindAsync(entity.Id);
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
