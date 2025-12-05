using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace KooliProjekt.Application.Data.Repositories
{
    public class TournamentRepository : ITournamentRepository
    {
        private readonly KooliProjekt.Application.Data.Models.ApplicationDbContext _dbContext;

        public TournamentRepository(KooliProjekt.Application.Data.Models.ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<KooliProjekt.Application.Data.Models.Tournament> GetByIdAsync(int id)
        {
            return await _dbContext.Tournaments.Include(t => t.Games).Where(t => t.Id == id).FirstOrDefaultAsync();
        }

        public async Task SaveAsync(KooliProjekt.Application.Data.Models.Tournament entity)
        {
            if (entity.Id != 0)
                _dbContext.Tournaments.Update(entity);
            else
                await _dbContext.Tournaments.AddAsync(entity);

            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(KooliProjekt.Application.Data.Models.Tournament entity)
        {
            _dbContext.Tournaments.Remove(entity);
            await _dbContext.SaveChangesAsync();
        }
    }
}
