using KooliProjekt.Application.Infrastructure.Results;
using MediatR;
using System;

namespace KooliProjekt.Application.Features.Games
{
    public class GetGameQuery : IRequest<OperationResult<object>>
    {
        public int Id { get; set; }
    }
}

