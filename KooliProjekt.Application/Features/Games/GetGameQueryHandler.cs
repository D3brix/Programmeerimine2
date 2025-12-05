using KooliProjekt.Application.Data.Models;
using KooliProjekt.Application.Features.Games;
using KooliProjekt.Application.Infrastructure.Results;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace KooliProjekt.Application.Features.Games

{
    public class GetGameQueryHandler : IRequestHandler<GetGameQuery, OperationResult<object>>
    {
        private readonly ApplicationDbContext _dbContext;

        public GetGameQueryHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<OperationResult<object>> Handle(GetGameQuery request, CancellationToken cancellationToken)
        {
            var result = new OperationResult<object>();

            result.Value = await _dbContext
                .Games
                .Where(list => list.Id == request.Id)
                .Select(list => new
                {
                    Id = list.Id,
                    Title = list.Title,
                   
                })
                .FirstOrDefaultAsync(cancellationToken: cancellationToken);

            return result;
        }
    }
}