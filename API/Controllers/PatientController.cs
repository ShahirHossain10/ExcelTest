using Application.Repositories;
using Domain;
using DTO;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;
[Route("api/[controller]/[action]")]
[ApiController]
public class PatientController : ControllerBase
{
    private readonly IPatientRepository _patientRepository;

    public PatientController(IPatientRepository patientRepository)
    {
        _patientRepository = patientRepository;
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        var patients = _patientRepository.GetAll();
        return Ok(patients);
    }

    [HttpGet]
    public IActionResult Get(int id)
    {
        var deatils = _patientRepository.Get(id);
        if (deatils == null)
            return NotFound();

        return Ok(deatils);
    }

    [HttpPost]
    public IActionResult Post(NewPatientDto patient)
    {
        var newPatient = _patientRepository.Add(patient);

        if (newPatient == null)
        {
            return BadRequest();
        }

        return Ok(new
        {
            message = "New Patient Created Successfully!!!",
        });
    }

    [HttpPut]
    public IActionResult Put(NewPatientDto patient)
    {
        var updatedPatient = _patientRepository.Update(patient);

        if (updatedPatient == null)
        {
            return NotFound();
        }

        return Ok(new
        {
            message = "Patient Updated Successfully!!!",
        });
    }

    [HttpDelete]
    public IActionResult Delete(int id)
    {
        if (!_patientRepository.Delete(id))
        {
            return NotFound();
        }

        return Ok(new
        {
            message = "Patient Deleted Successfully!!!",
        });
    }
}
