using KooliProjekt.Application.Data;
using KooliProjekt.Application.Data.Models;
using KooliProjekt.Application.Infrastructure.Results;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace KooliProjekt.Application.Features.Tournament
{
    public class SaveTournamentCommandHandler : IRequestHandler<SaveTournamentCommand, OperationResult>
    {
        private readonly KooliProjekt.Application.Data.Repositories.ITournamentRepository _tournamentRepository;

        public SaveTournamentCommandHandler(KooliProjekt.Application.Data.Repositories.ITournamentRepository tournamentRepository)
        {
            _tournamentRepository = tournamentRepository;
        }

        public async Task<OperationResult> Handle(SaveTournamentCommand request, CancellationToken cancellationToken)
        {
            var result = new OperationResult();

            var entity = new KooliProjekt.Application.Data.Models.Tournament();
            if (request.Id != 0)
            {
                entity = await _tournamentRepository.GetByIdAsync(request.Id);
            }

            entity.Title = request.Title;

            await _tournamentRepository.SaveAsync(entity);

            return result;
        }
    }
}
