using Core.ResultBases;
using MediatR;

namespace Application.Features.Tests.Commands.Update;
public sealed record UpdateArabaCommand(int Id,string JsonData) : IRequest<ResultBase>;