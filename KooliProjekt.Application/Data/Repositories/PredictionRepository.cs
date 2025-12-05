using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace KooliProjekt.Application.Data.Repositories
{
    public class PredictionRepository : IPredictionRepository
    {
        private readonly KooliProjekt.Application.Data.Models.ApplicationDbContext _dbContext;

        public PredictionRepository(KooliProjekt.Application.Data.Models.ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<KooliProjekt.Application.Data.Models.Prediction> GetByIdAsync(int id)
        {
            return await _dbContext.Predictions.Where(p => p.Id == id).FirstOrDefaultAsync();
        }

        public async Task SaveAsync(KooliProjekt.Application.Data.Models.Prediction entity)
        {
            if (entity.Id != 0)
                _dbContext.Predictions.Update(entity);
            else
                await _dbContext.Predictions.AddAsync(entity);

            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(KooliProjekt.Application.Data.Models.Prediction entity)
        {
            _dbContext.Predictions.Remove(entity);
            await _dbContext.SaveChangesAsync();
        }
    }
}
