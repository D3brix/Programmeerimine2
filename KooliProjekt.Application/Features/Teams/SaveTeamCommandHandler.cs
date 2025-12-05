using KooliProjekt.Application.Data;
using KooliProjekt.Application.Data.Models;
using KooliProjekt.Application.Features.Teams;
using KooliProjekt.Application.Infrastructure.Results;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace KooliProjekt.Application.Features.Teams
{
    public class SaveTeamCommandHandler : IRequestHandler<SaveTeamCommand, OperationResult>
    {
        private readonly KooliProjekt.Application.Data.Repositories.ITeamRepository _teamRepository;

        public SaveTeamCommandHandler(KooliProjekt.Application.Data.Repositories.ITeamRepository teamRepository)
        {
            _teamRepository = teamRepository;
        }

        public async Task<OperationResult> Handle(SaveTeamCommand request, CancellationToken cancellationToken)
        {
            var result = new OperationResult();

            var entity = new KooliProjekt.Application.Data.Models.Team();
            if (request.Id != 0)
            {
                entity = await _teamRepository.GetByIdAsync(request.Id);
            }

            entity.Title = request.Title;

            await _teamRepository.SaveAsync(entity);

            return result;
        }
    }
}
