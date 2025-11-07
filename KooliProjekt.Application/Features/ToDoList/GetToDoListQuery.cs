using KooliProjekt.Application.Infrastructure.Results;
using MediatR;
using System;

namespace KooliProjekt.Application.Features.ToDoLists
{
    public class GetToDoListQuery : IRequest<OperationResult<object>>
    {
        public int Id { get; set; }
    }
}

