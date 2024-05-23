using System.Text.Json.Serialization;

namespace Domain;

public class NCD_Detail
{
    public int Id { get; set; }
    public int PatientId { get; set; }

    [JsonIgnore]
    public Patient? Patient { get; set; }
    public int NCDId { get; set; }

    public NCD? NCD { get; set; }
}
