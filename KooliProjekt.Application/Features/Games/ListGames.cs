using System.Collections.Generic;
using MediatR;
using KooliProjekt.Application.Data.Models;

public record ListGamesQuery() : IRequest<List<Game>>
{
    public int Page { get; set; }
    public int PageCount { get; set; }
}

