using KooliProjekt.Application.Data.Models;
using KooliProjekt.Application.Infrastructure.Results;
using MediatR;
using System;

namespace KooliProjekt.Application.Features.Predictions
{
    public class GetPredictionQuery : IRequest<OperationResult<object>>
    {
        public int Id { get; set; }
    }
}

