using System.Text.Json.Serialization;

namespace Domain;

public class Allergie_Detail
{
    public int Id { get; set; }
    public int PatientId { get; set; }
    [JsonIgnore]
    public Patient? Patient { get; set; }
    public int AllergieId { get; set; }
    public Allergie? Allergie { get; set; }
}