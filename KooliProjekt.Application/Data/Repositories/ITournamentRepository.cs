using System.Threading.Tasks;

namespace KooliProjekt.Application.Data.Repositories
{
    public interface ITournamentRepository
    {
        Task<KooliProjekt.Application.Data.Models.Tournament> GetByIdAsync(int id);
        Task SaveAsync(KooliProjekt.Application.Data.Models.Tournament entity);
        Task DeleteAsync(KooliProjekt.Application.Data.Models.Tournament entity);
    }
}
