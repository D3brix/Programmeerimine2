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
        private readonly ApplicationDbContext _dbContext;

        public SaveTournamentCommandHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<OperationResult> Handle(SaveTournamentCommand request, CancellationToken cancellationToken)
        {
            var result = new OperationResult();

        
            KooliProjekt.Application.Data.Models.Tournament tournament;

            if (request.Id == 0)
            {
                tournament = new KooliProjekt.Application.Data.Models.Tournament();
                await _dbContext.Tournaments.AddAsync(tournament, cancellationToken);
            }
            else
            {
                tournament = await _dbContext.Tournaments.FindAsync(new object[] { request.Id }, cancellationToken);
                if (tournament == null)
                {
                    result.IsSuccess = false;
                    result.Message = "Tournament not found.";
                    return result;
                }
            }

         
            tournament.Title = request.Title;

            await _dbContext.SaveChangesAsync(cancellationToken);

            result.IsSuccess = true;
            result.Message = "Tournament saved successfully.";
            return result;
        }
    }
}
