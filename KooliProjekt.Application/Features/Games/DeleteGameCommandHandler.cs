using KooliProjekt.Application.Data;
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

namespace KooliProjekt.Application.Features.Games
{
    /// <summary>
    /// 14.11.2025
    /// Listi kustutamise commandi handler. 
    /// Handle meetodis toimub tegelik kustutamine
    /// Muutuja request tuleb sisse brauserist
    /// </summary>
    public class DeleteGameCommandHandler : IRequestHandler<DeleteGameCommand, OperationResult>
    {
        private readonly ApplicationDbContext _dbContext;

        public DeleteGameCommandHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<OperationResult> Handle(DeleteGameCommand request, CancellationToken cancellationToken)
        {
            var result = new OperationResult();

            await _dbContext
                .Games
                .Where(t => t.Id == request.Id)
                .ExecuteDeleteAsync();

            return result;
        }
    }
}
