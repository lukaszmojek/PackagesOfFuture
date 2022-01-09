using Microsoft.Extensions.Configuration;

namespace Api.Configuration;

public class PofConfiguration : IPofConfiguration
{
    private readonly IConfiguration _configuration;
    
    public PofConfiguration(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public string JwtSecret() 
        => _configuration.GetSection("Authorization")["Secret"];
}