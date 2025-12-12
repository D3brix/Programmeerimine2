using KooliProjekt.Application.Behaviors;
using KooliProjekt.Application.Infrastructure.Results;
using MediatR;
using System;

namespace KooliProjekt.Application.Features.Games
{
    public class SaveGameCommand : IRequest<OperationResult>, ITransactional
    {
        public int Id { get; set; }
        public string Title { get; set; }

        public DateTime Begins { get; set; }
        public DateTime Ends { get; set; }
        public DateTime Date { get; set; }

        public int Team1Id { get; set; }
        public int Team2Id { get; set; }

        public int Team1Score { get; set; }
        public int Team2Score { get; set; }

        public int TournamentId { get; set; }
    }
}
