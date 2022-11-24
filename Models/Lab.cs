using Newtonsoft.Json;

namespace Capstone.LabManagement.Models;

public struct Lab
{
    [JsonIgnore]
    public int Id { get; set; }

    [JsonProperty("Name")]
    public string Name { get; set; }
}