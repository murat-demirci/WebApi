using Application.Features.Tests.Rules;
using Application.Services;
using Core.ResultBases;
using Dapper;
using Domain.Entities;
using MediatR;
using Newtonsoft.Json;

namespace Application.Features.Tests.Commands.Create;
public sealed class CreateArabaCommandHandler(IArabaRepository arabaRepository) : IRequestHandler<CreateArabaCommand, ResultBase>
{
    public async Task<ResultBase> Handle(CreateArabaCommand request, CancellationToken cancellationToken)
    {
        ArabaBussinesRules arabaBussinesRules = new();
        if (!arabaBussinesRules.RequestDataTypeMustBeJson(request.Json))
            return new(false);

        var araba = JsonConvert.DeserializeObject<Araba>(request.Json);

        DynamicParameters parameters = new();
        parameters.Add("@brand", araba.Brand);
        parameters.Add("@model", araba.Model);
        parameters.Add("@color", araba.Color);
        parameters.Add("@engineSize", araba.EngineSize);
        parameters.Add("@price", araba.Price);
        parameters.Add("@year", araba.Year);
        var response = await arabaRepository.SaveDataAsync("InsertAraba", parameters);

        return new(response);
    }
}
