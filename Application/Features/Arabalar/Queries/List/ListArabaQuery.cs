using Core.ResultBases;
using MediatR;

namespace Application.Features.Tests.Queries.List;
public sealed record ListArabaQuery : IRequest<ResultBase<string>>;
