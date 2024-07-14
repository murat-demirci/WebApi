using Application.Services;
using Core.ResultBases;
using Dapper;
using MediatR;

namespace Application.Features.Tests.Commands.Delete;
public sealed class DeleteArabaCommandHandler(IArabaRepository arabaRepository) : IRequestHandler<DeleteArabaCommand, ResultBase>
{
    public async Task<ResultBase> Handle(DeleteArabaCommand request, CancellationToken cancellationToken)
    {
        DynamicParameters parameters = new();
        parameters.Add("@id", request.Id);
        var response = await arabaRepository.SaveDataAsync("DeleteArabaById", parameters);

        return new(response);
    }
}
