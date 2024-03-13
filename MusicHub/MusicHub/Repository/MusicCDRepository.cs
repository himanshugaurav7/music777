using Microsoft.EntityFrameworkCore;
using MusicHub.Data;
using MusicHub.Model;
using MusicHub.Repository.IRepository;
using System.Linq.Expressions;

namespace MusicHub.Repository
{
    public class MusicCDRepository : IMusicCDRepository
    {
        private readonly MusicHubDBContext _context;

        public MusicCDRepository(MusicHubDBContext context)
        {
            
            _context = context;
        }
           
        public async Task Create(MusicCD entity)
        {
           await  _context.MusicCDs.AddAsync(entity);
            await Save();
        }

        public async Task<MusicCD> Get(Expression<Func<MusicCD, bool>> filter, bool tracked=true)
        {
            IQueryable<MusicCD> musicCD = _context.MusicCDs;
            if (!tracked)
            {
                musicCD = musicCD.AsNoTracking();
            }
            if (filter != null)
            {
                musicCD = musicCD.Where(filter);
            }
            return await musicCD.FirstOrDefaultAsync();

        }

        public async Task<List<MusicCD>> GetAll(Expression<Func<MusicCD, bool>> filter)
        {

            IQueryable<MusicCD> musicCD = _context.MusicCDs;
            if (filter !=null)
            {
                musicCD = musicCD.Where(filter);
            }
            return await musicCD.ToListAsync();

        }

        public async Task Remove(MusicCD entity)
        {
            _context.MusicCDs.Remove(entity);
            await Save();
        }
        public async Task Update(MusicCD entity)
        {
            _context.MusicCDs.Update(entity);
            await Save();
        }

        public async Task Save()
        {
             await _context.SaveChangesAsync();
        }
    }
}
