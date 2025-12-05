using System.Threading.Tasks;

namespace KooliProjekt.Application.Data.Repositories
{
    public interface IPredictionRepository
    {
        Task<KooliProjekt.Application.Data.Models.Prediction> GetByIdAsync(int id);
        Task SaveAsync(KooliProjekt.Application.Data.Models.Prediction entity);
        Task DeleteAsync(KooliProjekt.Application.Data.Models.Prediction entity);
    }
}
