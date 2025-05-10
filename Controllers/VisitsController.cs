using Microsoft.AspNetCore.Mvc;
using apbd16_ex4.Models;

namespace apbd16_ex4.Controllers;

[Route("api/animals/{animalId}/[controller]")]
[ApiController]
public class VisitsController : ControllerBase
{
    [HttpGet]
    public IActionResult Get(int animalId)
    {
        var visits = Database.Visits.Where(v => v.AnimalId == animalId);
        return Ok(visits);
    }

    [HttpPost]
    public IActionResult Add(int animalId, Visit visit)
    {
        visit.Id = Database.Visits.Max(v => v.Id) + 1;
        visit.AnimalId = animalId;
        Database.Visits.Add(visit);
        return Created("", visit);
    }
}