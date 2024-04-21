using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Inforce.BLL.DTO.Shorten;
using Inforce.BLL.MediatR.Shorten.Create;
using Inforce.BLL.MediatR.Shorten.Delete;
using Inforce.BLL.MediatR.Shorten.GetAll;
using Inforce.BLL.MediatR.Shorten.GetById;

namespace Inforce.WebAPI.Controllers.Shorten;

public class ShortenerController : BaseApiController
{
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] ShortShortenDTO shortenDto)
    {
        return HandleResult(await Mediator.Send(new CreateShortenCommand(shortenDto, HttpContext)));
    }

    [Authorize(AuthenticationSchemes = "Bearer")]
    [HttpDelete("{id:int}")]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    public async Task<IActionResult> Delete(int id)
    {
        return HandleResult(await Mediator.Send(new DeleteShortenCommand(id)));
    }
    
    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetById(int id)
    {
        return HandleResult(await Mediator.Send(new GetShortenByIdQuery(id)));
    }
    
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        return HandleResult(await Mediator.Send(new GetAllShortenQuery()));
    }
}