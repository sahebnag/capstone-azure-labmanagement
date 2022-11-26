using Newtonsoft.Json;

namespace Capstone.LabManagement.Models;

public struct Lab
{
    public int Id { get; internal set; }

    [JsonProperty("name")]
    public string? Name { get; set; }

    public struct LabCategory
    {
        public int Id { get; set; }
    }

    public struct LabAuthor
    {
        public int Id { get; set; }
    }

    [JsonProperty("category")]
    public LabCategory Category { get; set; }

    [JsonProperty("author")]
    public LabAuthor Author { get; set; }
}