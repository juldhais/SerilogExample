using Microsoft.AspNetCore.Mvc;
using SerilogExample.Services;

namespace SerilogExample.Controllers;

[Route("user")]
public class UserController : ControllerBase
{
    private readonly IUserService _userService;

    public UserController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpPost]
    public ActionResult Create([FromBody] User user)
    {
        try
        {
            _userService.Create(user);
            return Ok();
        }
        catch (Exception e)
        {
            var errorResponse = new
            {
                Status = StatusCodes.Status400BadRequest,
                Message = e.Message
            };
            return BadRequest(errorResponse);
        }
    }
}