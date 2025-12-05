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

namespace KooliProjekt.Application.Features.Tournament
{
    public class GetTournamentQueryHandler : IRequestHandler<GetTournamentQuery, OperationResult<object>>
    {
        private readonly ApplicationDbContext _dbContext;

        public GetTournamentQueryHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<OperationResult<object>> Handle(GetTournamentQuery request, CancellationToken cancellationToken)
        {
            var result = new OperationResult<object>();

            result.Value = await _dbContext
                .Tournaments
                .Where(list => list.Id == request.Id)
                .Select(list => new
                {
                    Id = list.Id,
                    Title = list.Title,
                   
                })
                .FirstOrDefaultAsync();

            return result;
        }
    }
}