public class Data : IData
{
    private static List<string> _data = new List<string>();
    
     private IConfig _config;

    public Data(IConfig config)
    {
        _config = config;
    }

    public List<string> GetAll()
    {
        return _data;
    }

    public List<string> Find(string filterName)
    {
        return _data.Where(x => x.StartsWith(filterName)).ToList<string>();
    }

    public List<string> Add(string data)
    {
        _data.Add(_config.Prefix + data);
        return this.GetAll();
    }

    public List<string> Delete(string data)
    {

        _data.Remove(data);
        return this.GetAll();
    }
}