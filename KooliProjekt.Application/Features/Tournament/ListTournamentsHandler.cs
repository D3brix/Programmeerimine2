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

public class ListTournamentHandler : IRequestHandler<ListTournamentsQuery, List<Tournament>>
{
    private readonly ApplicationDbContext _context;

    public ListTournamentHandler(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<Tournament>> Handle(ListTournamentsQuery request, CancellationToken cancellationToken)
    {
        return await _context.Tournaments.ToListAsync(cancellationToken);
    }
}

