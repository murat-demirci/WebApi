using Application.Services;
using Core.ResultBases;
using Dapper;
using MediatR;
using Newtonsoft.Json;

namespace Application.Features.Tests.Queries.GetByMarka;
public sealed class GetByIDQueryHandler(IArabaRepository arabaRepository) : IRequestHandler<GetByIDQuery, ResultBase<string>>
{
    public async Task<ResultBase<string>> Handle(GetByIDQuery request, CancellationToken cancellationToken)
    {
        DynamicParameters parameters = new();
        parameters.Add("@id",request.Id);
        var araba = await arabaRepository.LoadDataAsync("GetByID", parameters);

        if (!araba.Any())
            return new(true);

        return new(true, JsonConvert.SerializeObject(araba,Formatting.None));
    }
}
