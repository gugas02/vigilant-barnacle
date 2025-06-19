using Ambev.DeveloperEvaluation.Application.Common;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Ambev.DeveloperEvaluation.WebApi.Common;

[Route("api/[controller]")]
[ApiController]
public class BaseController : ControllerBase
{
    protected int GetCurrentUserId() =>
            int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? throw new NullReferenceException());

    protected string GetCurrentUserEmail() =>
        User.FindFirst(ClaimTypes.Email)?.Value ?? throw new NullReferenceException();

    protected IActionResult BadRequestResult(List<FluentValidation.Results.ValidationFailure> validationFailures) =>
        base.BadRequest(new ApiErrorResponse
        {
            Type = "ValidationError",
            Error = "Invalid input data",
            Detail = string.Join(" ", validationFailures.Select(x => x.ErrorMessage))
        });

    protected IActionResult CreatedResult<T>(T data) where T : ApiResponse =>
        base.Created(string.Empty, data);
        
    protected IActionResult OkResult<T>(T data) where T : ApiResponse =>
        base.Ok(data);
    
    protected IActionResult OkResult<T>(PaginatedList<T> data) where T : ApiResponse =>
        base.Ok(data);
}
