using KooliProjekt.Application.Infrastructure.Results;
using MediatR;
using System;

namespace KooliProjekt.Application.Features.Tournament
{
    public class GetTournamentQuery : IRequest<OperationResult<object>>
    {
        public int Id { get; set; }
    }
}

