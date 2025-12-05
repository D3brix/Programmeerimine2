using KooliProjekt.Application.Data;
using KooliProjekt.Application.Data.Models;
using KooliProjekt.Application.Infrastructure.Results;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace KooliProjekt.Application.Features.Predictions
{
    public class SavePredictionCommandHandler : IRequestHandler<SavePredictionCommand, OperationResult>
    {
        private readonly ApplicationDbContext _dbContext;

        public SavePredictionCommandHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<OperationResult> Handle(SavePredictionCommand request, CancellationToken cancellationToken)
        {
            var result = new OperationResult();

            //var list = new ToDoList();
            //if (request.Id == 0)
            //{
            //    await _dbContext.ToDoLists.AddAsync(list);
            //}
            //else
            //{
            //    list = await _dbContext.ToDoLists.FindAsync(request.Id);
            //    //_dbContext.ToDoLists.Update(list);
            //}

            //list.Title = request.Title;

            //await _dbContext.SaveChangesAsync();

            return result;
        }
    }
}
