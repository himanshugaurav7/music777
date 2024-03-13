using MusicHub.Model;
using System.Linq.Expressions;

namespace MusicHub.Repository.IRepository
{
    public interface IMusicCDRepository
    {
        Task<List<MusicCD>> GetAll(Expression<Func<MusicCD,bool>> filter = null);
        Task<MusicCD> Get(Expression<Func<MusicCD, bool>> filter = null, bool tracked = true);
        Task Create(MusicCD entity);
        Task Remove(MusicCD entity);
        Task Update(MusicCD entity);
        Task Save();
    }
}
