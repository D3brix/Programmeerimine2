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

namespace KooliProjekt.Application.Features.Teams
{

    public class GetTeamQueryHandler : IRequestHandler<GetTeamQuery, OperationResult<object>>
    {
        private readonly KooliProjekt.Application.Data.Repositories.ITeamRepository _teamRepository;

        public GetTeamQueryHandler(KooliProjekt.Application.Data.Repositories.ITeamRepository teamRepository)
        {
            _teamRepository = teamRepository;
        }

        public async Task<OperationResult<object>> Handle(GetTeamQuery request, CancellationToken cancellationToken)
        {
            var result = new OperationResult<object>();

            var t = await _teamRepository.GetByIdAsync(request.Id);

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