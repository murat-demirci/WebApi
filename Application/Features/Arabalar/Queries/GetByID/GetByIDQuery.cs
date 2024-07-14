using Core.ResultBases;
using MediatR;

namespace Application.Features.Tests.Queries.GetByMarka;
public sealed record GetByIDQuery(int Id) : IRequest<ResultBase<string>>;
