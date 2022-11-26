using Newtonsoft.Json;

namespace Capstone.LabManagement.Models;

public struct Lab
{
    public int Id { get; internal set; }

    [JsonProperty("name")]
    public string? Name { get; set; }

    [JsonProperty("category")]
    public Category? Category { get; set; }

    [JsonProperty("author")]
    public Author? Author { get; set; }
}