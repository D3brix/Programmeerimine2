using KooliProjekt.Application.Data;
using KooliProjekt.Application.Data.Models;
using KooliProjekt.Application.Features.Games;
using KooliProjekt.Application.Infrastructure.Results;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace KooliProjekt.Application.Features.Games
{
    public class SaveGameCommandHandler : IRequestHandler<SaveGameCommand, OperationResult>
    {
        private readonly KooliProjekt.Application.Data.Repositories.IGameRepository _gameRepository;

        public SaveGameCommandHandler(KooliProjekt.Application.Data.Repositories.IGameRepository gameRepository)
        {
            _gameRepository = gameRepository;
        }

        public async Task<OperationResult> Handle(SaveGameCommand request, CancellationToken cancellationToken)
        {
            var result = new OperationResult();

            var entity = new KooliProjekt.Application.Data.Models.Game();
            if (request.Id != 0)
            {
                entity = await _gameRepository.GetByIdAsync(request.Id);
            }

            entity.Title = request.Title;

            await _gameRepository.SaveAsync(entity);

            return result;
        }
    }
}
