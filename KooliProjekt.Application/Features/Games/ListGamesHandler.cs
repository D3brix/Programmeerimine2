using KooliProjekt.Application.Data;
using KooliProjekt.Application.Data.Models;
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
    public class ListGamesHandler : IRequestHandler<ListGamesQuery, List<Game>>
    {
        private readonly ApplicationDbContext _context;

        public ListGamesHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Game>> Handle(ListGamesQuery request, CancellationToken cancellationToken)
        {
            return await _context.Games.ToListAsync(cancellationToken);
        }
    }
}