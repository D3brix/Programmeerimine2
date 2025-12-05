using KooliProjekt.Application.Infrastructure.Results;
using MediatR;

namespace KooliProjekt.Application.Features.Teams
{
    /// <summary>
    /// 14.11.2025
    /// Listi kustutamise command
    /// </summary>
    public class DeleteTeamCommand : IRequest<OperationResult>
    {
        public int Id { get; set; }
    }
}
