using Application.Features.Tests.Rules;
using Application.Services;
using Core.ResultBases;
using Dapper;
using Domain.Entities;
using MediatR;
using Newtonsoft.Json;

namespace Application.Features.Tests.Commands.Update;
public sealed class UpdateArabaCommandHandler(IArabaRepository arabaRepository) : IRequestHandler<UpdateArabaCommand, ResultBase>
{
    public async Task<ResultBase> Handle(UpdateArabaCommand request, CancellationToken cancellationToken)
    {
        ArabaBussinesRules arabaBussinesRules = new();
        if (!arabaBussinesRules.RequestDataTypeMustBeJson(request.JsonData))
            return new(false);

        var araba = JsonConvert.DeserializeObject<Araba>(request.JsonData);

        DynamicParameters parameters = new();
        parameters.Add("@id", request.Id);
        parameters.Add("@brand", araba.Brand);
        parameters.Add("@model", araba.Model);
        parameters.Add("@color", araba.Color);
        parameters.Add("@engineSize", araba.EngineSize);
        parameters.Add("@price", araba.Price);
        parameters.Add("@year", araba.Year);
        
        var response = await arabaRepository.SaveDataAsync("UpdateAraba", parameters);
        return new(response);
    }
}
