using Microsoft.EntityFrameworkCore;
using YumBlazor.Data;
using YumBlazor.Repository.IRepository;

namespace YumBlazor.Repository
{
    public class OrderRepository(ApplicationDbContext db) : IOrderRepository
    {
        private readonly ApplicationDbContext _db = db;

        public async Task<OrderHeader> CreateAsync(OrderHeader orderHeader)
        {
            orderHeader.OrderDate = DateTime.Now;
            await _db.OrderHeaders.AddAsync(orderHeader);
            await _db.SaveChangesAsync();
            return orderHeader;
        }

        public async Task<IEnumerable<OrderHeader>> GetAllAsync(string? userId = null)
        {
            if (!string.IsNullOrEmpty(userId))
                return await _db.OrderHeaders.Where(_ => _.UserId == userId).ToListAsync();

            return await _db.OrderHeaders.ToListAsync();
        }

        public async Task<OrderHeader> GetAsync(int id)
        {
            return await _db.OrderHeaders.Include(_ => _.OrderDetails).FirstOrDefaultAsync(_ => _.Id == id);
        }

        public async Task<OrderHeader> UpdateStatusAsync(int orderId, string status)
        {
            var orderHeader = await _db.OrderHeaders.FirstOrDefaultAsync(_ => _.Id == orderId);
            if(orderHeader != null)
            {
                orderHeader.Status = status;
                await _db.SaveChangesAsync();
            }

            return orderHeader;
        }
    }
}
