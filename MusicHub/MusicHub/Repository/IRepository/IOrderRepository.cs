using MusicHub.Model;
using System.Linq.Expressions;

namespace MusicHub.Repository.IRepository
{
    public interface IOrderRepository
    {
        Task<List<Order>> GetAll(Expression<Func<Order, bool>> filter = null);
        Task<Order> Get(Expression<Func<Order, bool>> filter = null, bool tracked = true);
        Task Create(Order entity);
        Task Remove(Order entity);
        Task Update(Order entity);
        Task Save();
    }
}
