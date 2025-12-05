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
        private readonly KooliProjekt.Application.Data.Repositories.ITournamentRepository _tournamentRepository;

        public GetTournamentQueryHandler(KooliProjekt.Application.Data.Repositories.ITournamentRepository tournamentRepository)
        {
            _tournamentRepository = tournamentRepository;
        }

        public async Task<OperationResult<object>> Handle(GetTournamentQuery request, CancellationToken cancellationToken)
        {
            var result = new OperationResult<object>();

            var t = await _tournamentRepository.GetByIdAsync(request.Id);

            if (t != null)
            {
                result.Value = new
                {
                    Id = t.Id,
                    Title = t.Title
                };
            }

            return result;
        }
    }
}