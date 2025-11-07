using KooliProjekt.Application.Infrastructure.Results;
using MediatR;
using System;

namespace KooliProjekt.Application.Features.Teachers
{
    public class GetTeachersQuery : IRequest<OperationResult<object>>
    {
        public int Id { get; set; }
    }
}

