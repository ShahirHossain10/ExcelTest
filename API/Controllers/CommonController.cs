using Application.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;
[Route("api/[controller]/[action]")]
[ApiController]
public class CommonController : ControllerBase
{
    private readonly ICommonRepository _commonRepository;

    public CommonController(ICommonRepository commonRepository)
    {
        _commonRepository = commonRepository;
    }

    [HttpGet]
    public IActionResult GetAllergies()
    {
        var list = _commonRepository.GetAllAllergies();
        return Ok(list);
    }

    [HttpGet]
    public IActionResult GetNCD()
    {
        var list = _commonRepository.GetAllNCDs();
        return Ok(list);
    }

    [HttpGet]
    public IActionResult GetDiease()
    {
        var list = _commonRepository.GetAllDieases();
        return Ok(list);
    }

}
