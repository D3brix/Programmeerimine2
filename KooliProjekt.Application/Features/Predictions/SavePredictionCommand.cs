using KooliProjekt.Application.Behaviors;
using KooliProjekt.Application.Infrastructure.Results;
using MediatR;

namespace KooliProjekt.Application.Features.Predictions
{
    public class SavePredictionCommand : IRequest<OperationResult>, ITransactional
    {
        public int Id { get; set; }
        public int GameId { get; set; }
        public int Team1Id { get; set; }
        public int Team2Id { get; set; }
        public int Score1 { get; set; }
        public int Score2 { get; set; }
        public int Points { get; set; }
        public int StartTime { get; set; } 
        public int EndTime { get; set; }  
    }
}
