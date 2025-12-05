using System.Threading.Tasks;

namespace KooliProjekt.Application.Data.Repositories
{
    public interface IGameRepository
    {
        Task<KooliProjekt.Application.Data.Models.Game> GetByIdAsync(int id);
        Task SaveAsync(KooliProjekt.Application.Data.Models.Game entity);
        Task DeleteAsync(KooliProjekt.Application.Data.Models.Game entity);
    }
}
