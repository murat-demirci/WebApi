

using Domain.Entities;
using MediatR;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Application.Features.Tests.Rules;
public sealed class ArabaBussinesRules
{
    public bool RequestDataTypeMustBeJson(string jsonData)
    {
        try
        {
			var json = JsonConvert.DeserializeObject<Araba>(jsonData);
            return true;
		}
		catch (Exception ex)
		{
			//logging
			return false;
		}
    }
}
