using System.Collections.Generic;
using MediatR;
using KooliProjekt.Application.Data;

public record ListTeamsQuery() : IRequest<List<Team>>
{
    public int Page { get; set; }
    public int PageCount { get; set; }
}

