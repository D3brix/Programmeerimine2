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

namespace KooliProjekt.Application.Features.ToDoLists
{
    public class GetToDoListQueryHandler : IRequestHandler<GetToDoListQuery, OperationResult<object>>
    {
        public readonly ApplicationDbContext _dbContext;

        public GetToDoListQueryHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<OperationResult<object>> Handle(GetToDoListQuery request, CancellationToken cancellationToken)
        {
            var result = new OperationResult<object>();

            result.Value = await _dbContext
                .ToDoLists
                .Include(list => list.Items)
                .Where(list => list.Id == request.Id)
                .Select(list => new
                {
                    Id = list.Id,
                    Title = list.Title,
                    Items = list.Items.Select(item => new
                    {
                        item.Id,
                        item.Title
                    })
                })
                .FirstOrDefaultAsync();

            return result;
        }
    }
}