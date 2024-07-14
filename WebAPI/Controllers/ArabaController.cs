using Application.Features.Tests.Commands.Create;
using Application.Features.Tests.Commands.Delete;
using Application.Features.Tests.Commands.Update;
using Application.Features.Tests.Queries.GetByMarka;
using Application.Features.Tests.Queries.List;
using Core.ResultBases;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;
[Route("api/[controller]")]
[ApiController]
public sealed class ArabaController : BaseController
{
    [HttpGet("{id}")]
    [Produces("application/json")]
    [ProducesResponseType(200, Type = typeof(GetByIDQueryDto))]
    public async Task<IActionResult> GetByPlaka([FromRoute] int id, CancellationToken cancellationToken)
    {
        var response = await Mediator.Send(new GetByIDQuery(id), cancellationToken);
        return response.IsSucceeded ? Ok(response) : BadRequest(response);
    }

    [HttpGet("List")]
    [Produces("application/json")]
    [ProducesResponseType(200, Type = typeof(IEnumerable<ListArabaQueryDto>))]
    public async Task<IActionResult> List(CancellationToken cancellationToken)
    {
        var response = await Mediator.Send(new ListArabaQuery(), cancellationToken);
        return response.IsSucceeded ? Ok(response) : BadRequest(response);
    }

    [HttpPost]
    [Produces("application/json")]
    [ProducesResponseType(200, Type = typeof(ResultBase))]
    public async Task<IActionResult> Create([FromBody] CreateArabaCommand createTestCommand,CancellationToken cancellationToken)
    {
        var response = await Mediator.Send(createTestCommand, cancellationToken);
        return response.IsSucceeded ? Ok(response) : BadRequest(response);
    }

    [HttpDelete("{id}")]
    [Produces("application/json")]
    [ProducesResponseType(200, Type = typeof(ResultBase))]
    public async Task<IActionResult> Delete([FromRoute] int id, CancellationToken cancellationToken)
    {
        var response = await Mediator.Send(new DeleteArabaCommand(id), cancellationToken);
        return response.IsSucceeded ? Ok(response) : BadRequest(response);
    }

    [HttpPut]
    [Produces("application/json")]
    [ProducesResponseType(200, Type = typeof(ResultBase))]
    public async Task<IActionResult> Update([FromBody] UpdateArabaCommand updateTestCommand, CancellationToken cancellationToken)
    {
        var response = await Mediator.Send(updateTestCommand, cancellationToken);
        return response.IsSucceeded ? Ok(response) : BadRequest(response);
    }
}
