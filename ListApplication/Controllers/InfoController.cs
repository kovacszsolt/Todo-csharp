using System.Net;
using Microsoft.AspNetCore.Mvc;

namespace ListApplication.Controllers;

[ApiController]
[Route("info")]
public class InfoController : ControllerBase
{
    private IConfig _config;

    static bool _healthState = true;

    public InfoController(IConfig config)
    {
        _config = config;
    }

    [HttpGet("")]
    public string GetInfo()
    {
        return _config.Prefix;
    }


    [HttpGet("health")]
    public IActionResult GetHealth()
    {
        if (_healthState)
        {
            return Ok();
        }
        else
        {
            return StatusCode(500);
        }
    }

    [HttpPost("health")]
    public bool SetHealth(bool state)
    {
        _healthState = state;
        return _healthState;
    }
}
