using System;
using System.Threading.Tasks;

namespace KooliProjekt.Application.Data.Repositories
{
    public abstract class BaseRepository<T> where T : KooliProjekt.Application.Data.Models.Entity
    {
        protected KooliProjekt.Application.Data.Models.ApplicationDbContext DbContext { get; private set; }

        public BaseRepository(KooliProjekt.Application.Data.Models.ApplicationDbContext dbContext)
        {
            DbContext = dbContext;
        }

        public virtual async Task<T> GetByIdAsync(int id)
        {
            return await DbContext.Set<T>().FindAsync(id);
        }

        public async Task SaveAsync(T entity)
        {
            if (entity.Id != 0)
            {
                DbContext.Set<T>().Update(entity);
            }
            else
            {
                await DbContext.Set<T>().AddAsync(entity);
            }

            await DbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(T entity)
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));

            DbContext.Set<T>().Remove(entity);
            await DbContext.SaveChangesAsync();
        }
    }
}
