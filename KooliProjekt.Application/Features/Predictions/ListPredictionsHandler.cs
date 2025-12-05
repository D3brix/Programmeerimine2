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

namespace KooliProjekt.Application.Features.Predictions
{
    public class ListPredictionsHandler : IRequestHandler<ListPredictionsQuery, List<Prediction>>
    {
        private readonly ApplicationDbContext _context;

        public ListPredictionsHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Prediction>> Handle(ListPredictionsQuery request, CancellationToken cancellationToken)
        {
            // Example implementation, adjust as needed
            return await _context.Predictions
                .Include(p => p.Game)
                .Include(p => p.Team1)
                .Include(p => p.Team2)
                .Skip((request.Page - 1) * request.PageCount)
                .Take(request.PageCount)
                .ToListAsync(cancellationToken);
        }
    }
}

