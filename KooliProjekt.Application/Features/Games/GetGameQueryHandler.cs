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
        private readonly KooliProjekt.Application.Data.Repositories.IGameRepository _gameRepository;

        public GetGameQueryHandler(KooliProjekt.Application.Data.Repositories.IGameRepository gameRepository)
        {
            _gameRepository = gameRepository;
        }

        public async Task<OperationResult<object>> Handle(GetGameQuery request, CancellationToken cancellationToken)
        {
            var result = new OperationResult<object>();

            var g = await _gameRepository.GetByIdAsync(request.Id);

            if (g != null)
            {
                result.Value = new
                {
                    Id = g.Id,
                    Title = g.Title
                };
            }

            return result;
        }
    }
}