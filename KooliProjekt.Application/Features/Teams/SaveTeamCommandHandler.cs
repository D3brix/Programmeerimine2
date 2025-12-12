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
        private readonly ApplicationDbContext _dbContext;

        public SaveTeamCommandHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<OperationResult> Handle(SaveTeamCommand request, CancellationToken cancellationToken)
        {
            var result = new OperationResult();

            Team team;

            if (request.Id == 0)
            {
                team = new Team();
                await _dbContext.Teams.AddAsync(team, cancellationToken);
            }
            else
            {
                team = await _dbContext.Teams.FindAsync(new object[] { request.Id }, cancellationToken);
                if (team == null)
                {
                    result.IsSuccess = false;
                    result.Message = "Team not found.";
                    return result;
                }
            }

            team.Title = request.Title;

            await _dbContext.SaveChangesAsync(cancellationToken);

            result.IsSuccess = true;
            result.Message = "Team saved successfully.";
            return result;
        }
    }
}
