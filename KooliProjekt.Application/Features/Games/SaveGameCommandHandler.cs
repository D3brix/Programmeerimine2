using KooliProjekt.Application.Data;
using KooliProjekt.Application.Data.Models;
using KooliProjekt.Application.Features.Games;
using KooliProjekt.Application.Infrastructure.Results;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace KooliProjekt.Application.Features.Games
{
    public class SaveGameCommandHandler : IRequestHandler<SaveGameCommand, OperationResult>
    {
        private readonly ApplicationDbContext _dbContext;

        public SaveGameCommandHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<OperationResult> Handle(SaveGameCommand request, CancellationToken cancellationToken)
        {
            var result = new OperationResult();

           
            var team1 = await _dbContext.Teams.FindAsync(new object[] { request.Team1Id }, cancellationToken);
            var team2 = await _dbContext.Teams.FindAsync(new object[] { request.Team2Id }, cancellationToken);
            var tournament = await _dbContext.Tournaments.FindAsync(new object[] { request.TournamentId }, cancellationToken);

            if (team1 == null || team2 == null)
            {
                result.IsSuccess = false;
                result.Message = "One or both teams do not exist.";
                return result;
            }

            if (tournament == null)
            {
                result.IsSuccess = false;
                result.Message = "Tournament does not exist.";
                return result;
            }

            Game game;

            if (request.Id == 0)
            {
                game = new Game();
                await _dbContext.Games.AddAsync(game, cancellationToken);
            }
            else
            {
                game = await _dbContext.Games.FindAsync(new object[] { request.Id }, cancellationToken);
                if (game == null)
                {
                    result.IsSuccess = false;
                    result.Message = "Game not found.";
                    return result;
                }
            }

           
            game.Title = request.Title;
            game.Begins = request.Begins;
            game.Ends = request.Ends;
            game.Date = request.Date;
            game.Team1Id = request.Team1Id;
            game.Team2Id = request.Team2Id;
            game.Team1Score = request.Team1Score;
            game.Team2Score = request.Team2Score;
            game.TournamentId = request.TournamentId;

            await _dbContext.SaveChangesAsync(cancellationToken);

            result.IsSuccess = true;
            result.Message = "Game saved successfully.";
            return result;
        }
    }
}
