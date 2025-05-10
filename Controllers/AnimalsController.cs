using Microsoft.AspNetCore.Mvc;
using apbd16_ex4.Models;

namespace apbd16_ex4.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AnimalsController : ControllerBase
{
    [HttpGet]
    public IActionResult Get()
    {
        return Ok(Database.Animals);
    }

    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        var animal = Database.Animals.FirstOrDefault(x => x.Id == id);
        return Ok(animal);
    }

    [HttpPost]
    public IActionResult Add(Animal animal)
    {
        animal.Id = Database.Animals.Max(x => x.Id) + 1;
        Database.Animals.Add(animal);
        return Created("", animal);
    }

    [HttpPut("{id}")]
    public IActionResult Update(int id, Animal updated)
    {
        var animal = Database.Animals.FirstOrDefault(x => x.Id == id);
        if (animal == null) return NotFound();

        animal.Name = updated.Name;
        animal.Category = updated.Category;
        animal.Weight = updated.Weight;
        animal.FurColor = updated.FurColor;

        return Ok();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var animal = Database.Animals.FirstOrDefault(x => x.Id == id);
        if (animal == null) return NotFound();

        Database.Animals.Remove(animal);
        return Ok();
    }

    [HttpGet("search/{name}")]
    public IActionResult Search(string name)
    {
        var result = Database.Animals.Where(x => x.Name.Contains(name, StringComparison.OrdinalIgnoreCase));
        return Ok(result);
    }
}