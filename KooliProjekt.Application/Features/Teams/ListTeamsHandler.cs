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

public class ListTeamsHandler : IRequestHandler<ListTeamsQuery, List<Team>>
{
    private readonly ApplicationDbContext _context;

    public ListTeamsHandler(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<Team>> Handle(ListTeamsQuery request, CancellationToken cancellationToken)
    {
        return await _context.Teams.ToListAsync(cancellationToken);
    }
}

