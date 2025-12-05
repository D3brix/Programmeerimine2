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
        private readonly ApplicationDbContext _dbContext;

        public GetPredictionQueryHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<OperationResult<object>> Handle(GetPredictionQuery request, CancellationToken cancellationToken)
        {
            var result = new OperationResult<object>();

            result.Value = await _dbContext
                .Predictions
                .Where(list => list.Id == request.Id)
                .Select(list => new
                {
                    Id = list.Id,
                    starttime = list.starttime,
                    points = list.points,
                    score1 = list.score1,
                    score2 = list.score2, 
                    GameId = list.GameId,
                    Team1Id = list.Team1Id,
                    Team2Id = list.Team2Id

                })
                .FirstOrDefaultAsync();

            return result;
        }
    }
}