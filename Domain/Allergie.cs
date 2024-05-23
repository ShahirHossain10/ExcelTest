using System.Text.Json.Serialization;

namespace Domain;

public class Allergie
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    [JsonIgnore]
    public List<Allergie_Detail>? Allergie_Details { get; set; }

}