using System.Text.Json;
public class Remote : IRemote
{
    static HttpClient client = new HttpClient();

    private IConfig _config;

    public Remote(IConfig config)
    {
        _config = config;
    }

    public async Task<string> GetInfo()
    {
        string responseString = "";
        List<string> responseList = new List<string>();
        HttpResponseMessage response = await client.GetAsync(_config.RemoteHost+ "/info/");
        if (response.IsSuccessStatusCode)
        {
            responseString = await response.Content.ReadAsStringAsync();
        }
        return responseString;
    }


    public async Task<List<string>> Add(string data)
    {
        string responseString = "";
        List<string> responseList = new List<string>();
        HttpResponseMessage response = await client.PostAsJsonAsync(_config.RemoteHost + "/data", data);
        if (response.IsSuccessStatusCode)
        {
            responseString = await response.Content.ReadAsStringAsync();
            responseList = JsonSerializer.Deserialize<List<string>>(responseString) ?? responseList;
        }
        return responseList;
    }
    public async Task<List<string>> GetAll()
    {
        string responseString = "";
        List<string> responseList = new List<string>();
        HttpResponseMessage response = await client.GetAsync(_config.RemoteHost + "/data/getall/");
        if (response.IsSuccessStatusCode)
        {
            responseString = await response.Content.ReadAsStringAsync();
            responseList = JsonSerializer.Deserialize<List<string>>(responseString) ?? responseList;
        }
        return responseList;
    }
}