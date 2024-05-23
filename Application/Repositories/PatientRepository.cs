using Domain;
using DTO;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Application.Repositories;
public class PatientRepository : IPatientRepository
{
    private readonly DataContext _context;

    public PatientRepository(DataContext context)
    {
        _context = context;
    }

    public Patient Add(NewPatientDto entity)
    {

        var patient = new Patient();
        if (entity != null)
        {
            patient.Id = entity.Id;
            patient.Name = entity.Name;
            patient.HasEpilepsy = entity.HasEpilepsy == 0 ? Epilepsy.No : Epilepsy.Yes;
            patient.DiseaseId = entity.DieaseId;

            patient.Allergie_Details = new List<Allergie_Detail>();
            patient.NCD_Details = new List<NCD_Detail>();
            foreach (var item in entity.NCDs)
            {
                var obj = new NCD_Detail()
                {
                    PatientId = patient.Id,
                    NCDId = item,
                };
                patient.NCD_Details.Add(obj);
            }

            foreach (var item in entity.Allergies)
            {
                var obj = new Allergie_Detail()
                {
                    PatientId = patient.Id,
                    AllergieId = item,
                };
                patient.Allergie_Details.Add(obj);
            }

            _context.Patients.Add(patient);
            _context.SaveChanges();
        }

        return patient;
    }
    private Patient GetById(int id)
    {
        return _context.Patients.FirstOrDefault(x => x.Id == id);
    }
    public bool Delete(int id)
    {
        var patient = GetById(id);
        if (patient != null)
        {
            _context.Patients.Remove(patient);
            _context.SaveChanges();

            return true;
        }
        return false;
    }

    public NewPatientDto Get(int id)
    {
        var patient = _context.Patients?.Include(d => d.Disease)
                                .Include(ad => ad.Allergie_Details).ThenInclude(a => a.Allergie)
                                .Include(nd => nd.NCD_Details).ThenInclude(n => n.NCD)
                                .AsNoTracking()
                                .Select(p => new NewPatientDto
                                {
                                    Id = p.Id,
                                    Name = p.Name,
                                    DieaseName = p.Disease.Name,
                                    Epilepsy = p.HasEpilepsy == 0 ? "No" : "Yes",
                                    AllergieNames = string.Join(", ", p.Allergie_Details.Select(x => x.Allergie.Name)),
                                    NCDNames = string.Join(",", p.NCD_Details.Select(x => x.NCD.Name)),
                                    HasEpilepsy = (int)p.HasEpilepsy,
                                    DieaseId = p.DiseaseId
                                })
                                .FirstOrDefault(x => x.Id == id);
        return patient;
    }

    public List<NewPatientDto> GetAll()
    {
        var patients = _context.Patients.Include(d => d.Disease)
                                        .AsNoTracking()
                                        .Select(p =>
                                            new NewPatientDto()
                                            {
                                                Id = p.Id,
                                                Name = p.Name,
                                                Epilepsy = p.HasEpilepsy == 0 ? "No" : "Yes",
                                                DieaseName = p.Disease.Name,
                                            });
        return patients.ToList();
    }
    public Patient Update(NewPatientDto entity)
    {
        var ncdDetailslist = _context.NCD_Details.Where(x => x.PatientId == entity.Id).ToList();
        var allerDetailsList = _context.Allergie_Details.Where(x => x.PatientId == entity.Id).ToList();

        _context.NCD_Details.RemoveRange(ncdDetailslist);
        _context.Allergie_Details.RemoveRange(allerDetailsList);
        _context.SaveChanges();
        var patient = _context.Patients.FirstOrDefault(x => x.Id == entity.Id);
        if (entity != null)
        {
            patient.Id = entity.Id;
            patient.Name = entity.Name;
            patient.HasEpilepsy = entity.HasEpilepsy == 0 ? Epilepsy.No : Epilepsy.Yes;
            patient.DiseaseId = entity.DieaseId;

            patient.Allergie_Details = new List<Allergie_Detail>();
            patient.NCD_Details = new List<NCD_Detail>();
            foreach (var item in entity.NCDs)
            {
                var obj = new NCD_Detail()
                {
                    PatientId = patient.Id,
                    NCDId = item,
                };
                patient.NCD_Details.Add(obj);
            }

            foreach (var item in entity.Allergies)
            {
                var obj = new Allergie_Detail()
                {
                    PatientId = patient.Id,
                    AllergieId = item,
                };
                patient.Allergie_Details.Add(obj);
            }

            _context.Patients.Update(patient);
            _context.SaveChanges();
        }

        return patient;
    }
}
