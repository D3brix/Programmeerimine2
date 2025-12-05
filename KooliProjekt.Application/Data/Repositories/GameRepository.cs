using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace KooliProjekt.Application.Data.Repositories
{
    public class GameRepository : IGameRepository
    {
        private readonly KooliProjekt.Application.Data.Models.ApplicationDbContext _dbContext;

        public GameRepository(KooliProjekt.Application.Data.Models.ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<KooliProjekt.Application.Data.Models.Game> GetByIdAsync(int id)
        {
            return await _dbContext.Games.Where(g => g.Id == id).FirstOrDefaultAsync();
        }

        public async Task SaveAsync(KooliProjekt.Application.Data.Models.Game entity)
        {
            if (entity.Id != 0)
                _dbContext.Games.Update(entity);
            else
                await _dbContext.Games.AddAsync(entity);

            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(KooliProjekt.Application.Data.Models.Game entity)
        {
            _dbContext.Games.Remove(entity);
            await _dbContext.SaveChangesAsync();
        }
    }
}
