using System.Threading.Tasks;

namespace KooliProjekt.Application.Data.Repositories
{
    public interface ITeamRepository
    {
        Task<KooliProjekt.Application.Data.Models.Team> GetByIdAsync(int id);
        Task SaveAsync(KooliProjekt.Application.Data.Models.Team entity);
        Task DeleteAsync(KooliProjekt.Application.Data.Models.Team entity);
    }
}
