using Microsoft.EntityFrameworkCore;
using MusicHub.Data;
using MusicHub.Model;
using MusicHub.Repository.IRepository;
using System.Linq.Expressions;

namespace MusicHub.Repository
{
    public class OrderRepository : IOrderRepository
    {
        private readonly MusicHubDBContext _context;

        public OrderRepository(MusicHubDBContext context)
        {
            
            _context = context;
        }
           
        public async Task Create(Order entity)
        {
           await  _context.Orders.AddAsync(entity);
            await Save();
        }

        public async Task<Order> Get(Expression<Func<Order, bool>> filter, bool tracked=true)
        {
            IQueryable<Order> order = _context.Orders;
            if (!tracked)
            {
                order = order.AsNoTracking();
            }
            if (filter != null)
            {
                order = order.Where(filter);
            }
            return await order.FirstOrDefaultAsync();

        }

        public async Task<List<Order>> GetAll(Expression<Func<Order, bool>> filter)
        {

            IQueryable<Order> order = _context.Orders;
            if (filter !=null)
            {
                order= order.Where(filter);
            }
            return await order.ToListAsync();

        }

        public async Task Remove(Order entity)
        {
            _context.Orders.Remove(entity);
            await Save();
        }
        public async Task Update(Order entity)
        {
            _context.Orders.Update(entity);
            await Save();
        }

        public async Task Save()
        {
             await _context.SaveChangesAsync();
        }
    }
}
