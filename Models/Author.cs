using Newtonsoft.Json;

namespace Capstone.LabManagement.Models;

public struct Author
{
    public int Id { get; internal set; }

    [JsonProperty("firstName")]
    public string? FirstName { get; set; }

    [JsonProperty("lastName")]
    public string? LastName { get; set; }
}