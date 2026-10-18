using CINEMA_System_APi.Data;
using CINEMA_System_APi.Reposatories.Interface;
using Microsoft.EntityFrameworkCore;

namespace CINEMA_System_APi.Reposatories.Implmentation
{
    public class GenericRepo<T> : IGenericRepo<T> where T : class
    {
        private readonly AppDbContext _context;
        private readonly DbSet<T> set;
        public GenericRepo(AppDbContext context)
        {
            _context = context;
            set = _context.Set<T>();
        }
        public async Task AddAsync(T entity)
        {
            await set.AddAsync(entity);
        }

        public async Task DeleteAsync(int id)
        {
            var item = await set.FindAsync(id);
            set.Remove(item);
        }

        public async Task<ICollection<T>> GetAllAsync()
        {
            return await set.ToListAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await set.FindAsync(id);
        }

        public async Task UpdateAsync(int id ,T entity)
        {
            var item = await set.FindAsync(id);
                _context.Entry(item).CurrentValues.SetValues(entity);
            
        }
    }
}
