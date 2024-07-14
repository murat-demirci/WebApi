using Core.ResultBases;
using MediatR;

namespace Application.Features.Tests.Commands.Delete;
public sealed record DeleteArabaCommand(int Id) : IRequest<ResultBase>;