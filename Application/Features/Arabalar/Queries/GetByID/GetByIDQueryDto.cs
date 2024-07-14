using Domain.Entities;

namespace Application.Features.Tests.Queries.GetByMarka;
public sealed record GetByIDQueryDto(IEnumerable<Araba> Arabalar);