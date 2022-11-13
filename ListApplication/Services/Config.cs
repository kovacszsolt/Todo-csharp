public class Config : IConfig
{
    private readonly IConfiguration Configuration;
    public Config(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    string IConfig.Prefix => Configuration["RunTimeSetting:Prefix"];


    string IConfig.RemoteHost => Configuration["RunTimeSetting:RemoteHost"];

    int IConfig.DelayTime => int.Parse(Configuration["RunTimeSetting:DelayTime"]);
}