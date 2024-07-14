using Application.Services;
using Core.ResultBases;
using MediatR;
using Newtonsoft.Json;

namespace Application.Features.Tests.Queries.List;
public sealed class ListArabaQueryHandler(IArabaRepository arabaRepository) : IRequestHandler<ListArabaQuery, ResultBase<string>>
{
    public async Task<ResultBase<string>> Handle(ListArabaQuery request, CancellationToken cancellationToken)
    {
        var list = await arabaRepository.LoadDataAsync("ListCars");

        if (list is null || !list.Any())
            return new(true);

        return new(true, JsonConvert.SerializeObject(list,Formatting.None));
    }
}
