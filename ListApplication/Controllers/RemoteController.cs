using Microsoft.AspNetCore.Mvc;

namespace ListApplication.Controllers;

[ApiController]

[Route("remote")]
public class RemoteController : ControllerBase
{
    private IRemote _remoteService;
    static HttpClient client = new HttpClient();
    public RemoteController(IRemote remoteService)
    {
        _remoteService=remoteService;
    }

    [HttpGet("info")]
    public async Task<string> GetInfo()
    {
        return await _remoteService.GetInfo();
    }

    [HttpGet("getall")]
    public async Task<List<string>> GetAll()
    {
        return await _remoteService.GetAll();
    }


    [HttpPost("add")]
    public async Task<List<string>> PostAdd([FromBody]PostData data)
    {
        return await _remoteService.Add(data.data);
    }

}
