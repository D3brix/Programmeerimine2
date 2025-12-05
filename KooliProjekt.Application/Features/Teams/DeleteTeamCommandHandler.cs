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

namespace KooliProjekt.Application.Features.Teams
{
    /// <summary>
    /// 14.11.2025
    /// Listi kustutamise commandi handler. 
    /// Handle meetodis toimub tegelik kustutamine
    /// Muutuja request tuleb sisse brauserist
    /// </summary>
    public class DeleteTeamCommandHandler : IRequestHandler<DeleteTeamCommand, OperationResult>
    {
        private readonly ApplicationDbContext _dbContext;

        public DeleteTeamCommandHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<OperationResult> Handle(DeleteTeamCommand request, CancellationToken cancellationToken)
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
