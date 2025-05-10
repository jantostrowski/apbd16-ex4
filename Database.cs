using apbd16_ex4.Models;

public static class Database
{
    public static List<Animal> Animals { get; } = new()
    {
        new Animal { Id = 1, Name = "Beza", Category = "Fretka", Weight = 2.6, FurColor = "Szary" },
        new Animal { Id = 2, Name = "Keks", Category = "Kot", Weight = 4.5, FurColor = "Pomarańczowy" }
    };

    public static List<Visit> Visits { get; } = new()
    {
        new Visit { Id = 1, AnimalId = 1, VisitDate = DateTime.Today, Description = "Krew", Price = 120 },
        new Visit { Id = 2, AnimalId = 2, VisitDate = DateTime.Today, Description = "Badanie", Price = 80 }
    };
}