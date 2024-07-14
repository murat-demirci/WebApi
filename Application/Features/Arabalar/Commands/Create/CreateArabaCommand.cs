using Core.ResultBases;
using MediatR;

namespace Application.Features.Tests.Commands.Create;
public sealed record CreateArabaCommand
    (string Json) : IRequest<ResultBase>;