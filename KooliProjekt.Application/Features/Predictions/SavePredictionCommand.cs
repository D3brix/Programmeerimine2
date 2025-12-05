using KooliProjekt.Application.Behaviors;
using KooliProjekt.Application.Infrastructure.Results;
using MediatR;

namespace KooliProjekt.Application.Features.Predictions
{
    public class SavePredictionCommand : IRequest<OperationResult>, ITransactional
    {
        public int Id { get; set; }
        public int score1 { get; set; }
        public int score2 { get; set; }
        public int starttime { get; set; }
        public int endtime { get; set; }
        public int points { get; set; }

        public int GameId { get; set; }
        public int Team1Id { get; set; }
        public int Team2Id { get; set; }
    }
}
