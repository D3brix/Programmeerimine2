using KooliProjekt.Application.Data;
using KooliProjekt.Application.Data.Models;
using KooliProjekt.Application.Features.Predictions;
using KooliProjekt.Application.Infrastructure.Results;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace KooliProjekt.Application.Features.Predictions
{
    public class SavePredictionCommandHandler : IRequestHandler<SavePredictionCommand, OperationResult>
    {
        private readonly ApplicationDbContext _dbContext;

        public SavePredictionCommandHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<OperationResult> Handle(SavePredictionCommand request, CancellationToken cancellationToken)
        {
            var result = new OperationResult();

         
            var game = await _dbContext.Games.FindAsync(new object[] { request.GameId }, cancellationToken);
            var team1 = await _dbContext.Teams.FindAsync(new object[] { request.Team1Id }, cancellationToken);
            var team2 = await _dbContext.Teams.FindAsync(new object[] { request.Team2Id }, cancellationToken);

            if (game == null || team1 == null || team2 == null)
            {
                result.IsSuccess = false;
                result.Message = "Game or one of the teams does not exist.";
                return result;
            }

            Prediction prediction;

            if (request.Id == 0)
            {
                prediction = new Prediction();
                await _dbContext.Predictions.AddAsync(prediction, cancellationToken);
            }
            else
            {
                prediction = await _dbContext.Predictions.FindAsync(new object[] { request.Id }, cancellationToken);
                if (prediction == null)
                {
                    result.IsSuccess = false;
                    result.Message = "Prediction not found.";
                    return result;
                }
            }

          
            prediction.GameId = request.GameId;
            prediction.Team1Id = request.Team1Id;
            prediction.Team2Id = request.Team2Id;
            prediction.Score1 = request.Score1;
            prediction.Score2 = request.Score2;
            prediction.Points = request.Points;
            prediction.StartTime = request.StartTime;
            prediction.EndTime = request.EndTime;

            await _dbContext.SaveChangesAsync(cancellationToken);

            result.IsSuccess = true;
            result.Message = "Prediction saved successfully.";
            return result;
        }
    }
}
