using KooliProjekt.Application.Data;
using KooliProjekt.Application.Data.Models;
using MediatR;
using System.Collections.Generic;

public record ListPredictionsQuery() : IRequest<List<Prediction>>
{
    public int Page { get; set; }
    public int PageCount { get; set; }
}

