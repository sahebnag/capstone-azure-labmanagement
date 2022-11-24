using Azure.Identity;
using Azure.Security.KeyVault.Secrets;

namespace Capstone.LabManagement.Configuration;


public class KeyVaultManager
{
    private readonly string _keyVaultUrl;
    private readonly SecretClient _client;
    public KeyVaultManager(IConfiguration config)
    {
        _keyVaultUrl = config.GetValue<string>("keyVaultUrl");
        _client = new SecretClient(new Uri(_keyVaultUrl), new DefaultAzureCredential());
    }

    public string GetSecret(string key)
    {
        return _client.GetSecret(key).Value.Value;
    }
}