using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace KooliProjekt.Application.Data.Repositories
{
    public class TeamRepository : ITeamRepository
    {
        private readonly KooliProjekt.Application.Data.Models.ApplicationDbContext _dbContext;

        public TeamRepository(KooliProjekt.Application.Data.Models.ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<KooliProjekt.Application.Data.Models.Team> GetByIdAsync(int id)
        {
            return await _dbContext.Teams.Where(t => t.Id == id).FirstOrDefaultAsync();
        }

        public async Task SaveAsync(KooliProjekt.Application.Data.Models.Team entity)
        {
            if (entity.Id != 0)
                _dbContext.Teams.Update(entity);
            else
                await _dbContext.Teams.AddAsync(entity);

            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(KooliProjekt.Application.Data.Models.Team entity)
        {
            _dbContext.Teams.Remove(entity);
            await _dbContext.SaveChangesAsync();
        }
    }
}
