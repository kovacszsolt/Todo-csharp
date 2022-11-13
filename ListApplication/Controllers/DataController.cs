using Microsoft.AspNetCore.Mvc;

namespace ListApplication.Controllers;

[ApiController]

[Route("data")]
public class DataController : ControllerBase
{
    private IData _dataService;
    private IConfig _config;
    public DataController(IData data, IConfig config)
    {
        _dataService=data;
        _config=config;
    }

    [HttpGet("getall")]
    public List<string> GetAll()
    {
        return _dataService.GetAll();
    }

    [HttpGet("getalldelay")]
    public List<string> GetAllDelay()
    {
        Thread.Sleep(_config.DelayTime);
        return _dataService.GetAll();
    }

    [HttpGet("find")]
    public List<string> Find(string filterName)
    {
        return _dataService.Find(filterName);
    }

    [HttpPost]
    public List<string> Post([FromBody]PostData data)
    {
        return _dataService.Add(data.data);
    }

    [HttpDelete]
    public List<string> Delete(string data)
    {
        return _dataService.Delete(data);
    }
}
