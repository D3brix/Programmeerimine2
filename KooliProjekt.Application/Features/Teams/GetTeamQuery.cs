using KooliProjekt.Application.Infrastructure.Results;
using MediatR;
using System;

namespace KooliProjekt.Application.Features.Teams
{
    public class GetTeamQuery : IRequest<OperationResult<object>>
    {
        public int Id { get; set; }
    }
}

