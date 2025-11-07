using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MediatR;
using System.Collections.Generic;
using KooliProjekt.Application.Data;

public record ListTeachersQuery() : IRequest<List<Teacher>>;

