using System.Text.Json.Serialization;

namespace Domain;

public class NCD
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;

    [JsonIgnore]
    public List<NCD_Detail>? NCD_Details { get; set; }
}
