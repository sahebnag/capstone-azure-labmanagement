namespace Capstone.LabManagement.Configuration;

public sealed class LabManagementDbConnection
{
    private readonly string _serverName;
    private readonly string _dbName;
    private readonly string _userName;
    private readonly string _password;

    public string ConnectionString { get; set; }


    public LabManagementDbConnection(KeyVaultManager vault)
    {
        _serverName = vault.GetSecret("labmanagement-servername");
        _dbName = vault.GetSecret("labmanagement-dbaname");
        _userName = vault.GetSecret("labmanagement-username");
        _password = vault.GetSecret("labmanagement-password");

        ConnectionString = $"Server={_serverName};Database={_dbName};User Id={_userName};Password={_password};";
    }
}