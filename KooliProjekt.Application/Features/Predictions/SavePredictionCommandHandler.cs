using KooliProjekt.Application.Data;
using KooliProjekt.Application.Data.Models;
using KooliProjekt.Application.Infrastructure.Results;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace KooliProjekt.Application.Features.Predictions
{
    public class SavePredictionCommandHandler : IRequestHandler<SavePredictionCommand, OperationResult>
    {
        private readonly KooliProjekt.Application.Data.Repositories.IPredictionRepository _predictionRepository;

        public SavePredictionCommandHandler(KooliProjekt.Application.Data.Repositories.IPredictionRepository predictionRepository)
        {
            _predictionRepository = predictionRepository;
        }

        public async Task<OperationResult> Handle(SavePredictionCommand request, CancellationToken cancellationToken)
        {
            var result = new OperationResult();

            var entity = new KooliProjekt.Application.Data.Models.Prediction();
            if (request.Id != 0)
            {
                entity = await _predictionRepository.GetByIdAsync(request.Id);
            }

            // map properties - adjust as needed
            entity.score1 = request.score1;
            entity.score2 = request.score2;
            entity.starttime = request.starttime;
            entity.endtime = request.endtime;
            entity.points = request.points;
            entity.GameId = request.GameId;
            entity.Team1Id = request.Team1Id;
            entity.Team2Id = request.Team2Id;

            await _predictionRepository.SaveAsync(entity);

            return result;
        }
    }
}
