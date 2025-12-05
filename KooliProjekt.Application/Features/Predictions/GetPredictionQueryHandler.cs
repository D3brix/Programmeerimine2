using KooliProjekt.Application.Data.Models;
using KooliProjekt.Application.Infrastructure.Results;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace KooliProjekt.Application.Features.Predictions
{
    public class GetPredictionQueryHandler : IRequestHandler<GetPredictionQuery, OperationResult<object>>
    {
        private readonly KooliProjekt.Application.Data.Repositories.IPredictionRepository _predictionRepository;

        public GetPredictionQueryHandler(KooliProjekt.Application.Data.Repositories.IPredictionRepository predictionRepository)
        {
            _predictionRepository = predictionRepository;
        }

        public async Task<OperationResult<object>> Handle(GetPredictionQuery request, CancellationToken cancellationToken)
        {
            var result = new OperationResult<object>();

            var p = await _predictionRepository.GetByIdAsync(request.Id);

            if (p != null)
            {
                result.Value = new
                {
                    Id = p.Id,
                    starttime = p.starttime,
                    points = p.points,
                    score1 = p.score1,
                    score2 = p.score2,
                    GameId = p.GameId,
                    Team1Id = p.Team1Id,
                    Team2Id = p.Team2Id
                };
            }

            return result;
        }
    }
}