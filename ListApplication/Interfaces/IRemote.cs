public interface IRemote
{
    public Task<List<string>> GetAll();

    public Task<string> GetInfo();


    public Task<List<string>> Add(string data);


}