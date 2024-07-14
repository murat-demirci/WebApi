using Domain.Entities;

namespace Application.Features.Tests.Queries.List;
public sealed record ListArabaQueryDto
{
    public IEnumerable<Araba> Arabalar { get; init; }
}

