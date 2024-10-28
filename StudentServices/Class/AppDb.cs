using System.Configuration;

namespace StudentServices.Class;


public class AppDb
{
    public IConfiguration Configuration { get; }

    public string GetConnection() => Configuration.GetSection("ConnectionStrings").GetSection("DbConstring").Value;

    public AppDb(IConfiguration configuration)
    {
        Configuration = configuration;
    }
}