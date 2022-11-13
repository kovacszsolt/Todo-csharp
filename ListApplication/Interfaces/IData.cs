public interface IData
{
    public List<string> GetAll();

    public List<string> Find(string filterName);

    public List<string> Add(string data);

    public List<string> Delete(string data);
}