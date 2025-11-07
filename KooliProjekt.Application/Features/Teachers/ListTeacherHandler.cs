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

public class ListTeachersHandler : IRequestHandler<ListTeachersQuery, List<Teacher>>
{
    private readonly ApplicationDbContext _context;

    public ListTeachersHandler(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<Teacher>> Handle(ListTeachersQuery request, CancellationToken cancellationToken)
    {
        return await _context.Teachers.ToListAsync(cancellationToken);
    }
}

