using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PassIn.Application.UseCases.CheckIns.DoCheckIns;
using PassIn.Communication.Responses;

namespace PassIn.Api.Controllers;
[Route("api/[controller]")]
[ApiController]
public class CheckInController : ControllerBase
{
    [HttpPost]
    [Route("{attendeeId}")]
    [ProducesResponseType(typeof(ResponseRegisteredJson), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status409Conflict)]

    public IActionResult Checkin([FromRoute] Guid attendeeId)
    {
        var useCase = new DoAttendeesCheckinUseCase();

        var response = useCase.Execute(attendeeId);

        return Created(string.Empty, response);
    }
}
