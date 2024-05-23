using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO;
public class NewPatientDto
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public int DieaseId { get; set; }
    public int HasEpilepsy { get; set; }

    public List<int>? NCDs { get; set; }
    public List<int> Allergies { get; set; } = new List<int>();

    public string DieaseName { get; set; } = string.Empty;
    public string AllergieNames { get; set; } = string.Empty;
    public string NCDNames { get; set; } = string.Empty;
    public string Epilepsy { get; set; } = string.Empty;


}
