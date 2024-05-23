using System.Text.Json.Serialization;

namespace Domain;
public class Patient
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public int DiseaseId { get; set; }

    public Disease? Disease { get; set; }
    public Epilepsy HasEpilepsy { get; set; } = Epilepsy.No;

    public List<NCD_Detail>? NCD_Details { get; set; }

    public List<Allergie_Detail>? Allergie_Details { get; set; }
}
