using DTO;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace WebClient.Controllers;
public class PatientController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
    public IActionResult Create()
    {
        return View();
    }
    public async Task<IActionResult> Details(int id)
    {
        var deatils = new NewPatientDto();
        string apiUrl = "https://localhost:44314/api/patient/Get?id=" + id;

        using (HttpClient client = new HttpClient())
        {
            client.BaseAddress = new Uri(apiUrl);


            HttpResponseMessage response = await client.GetAsync(apiUrl);
            if (response.IsSuccessStatusCode)
            {
                var data = await response.Content.ReadAsStringAsync();
                var options = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                };
                deatils = JsonSerializer.Deserialize<NewPatientDto>(data, options);
            }
        }
        return View(deatils);
    }

    public IActionResult Edit(int id)
    {
        return View();
    }

}
