using Newtonsoft.Json;

namespace Capstone.LabManagement.Models;

public struct Category
{
    [JsonIgnore]
    public int Id { get; internal set; }

    [JsonProperty("Name")]
    public string? Name { get; set; }
}