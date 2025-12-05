using System;
using KooliProjekt.Application.Infrastructure.Results;
using MediatR;

namespace KooliProjekt.Application.Features.Predictions
{
    /// <summary>
    /// 14.11.2025
    /// Listi kustutamise command
    /// </summary>
    public class DeletePredictionCommand : IRequest<OperationResult>
    {
        public int Id { get; set; }
    }
}
